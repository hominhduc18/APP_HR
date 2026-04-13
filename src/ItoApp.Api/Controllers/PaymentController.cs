using Microsoft.AspNetCore.Mvc;
using ItoApp.Api.Helpers;
using ItoApp.Infrastructure.Data;
using ItoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ItoApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _context;

    public PaymentController(IConfiguration configuration, ApplicationDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    /// <summary>
    /// 1. Tạo URL thanh toán qua VNPAY và lưu bản ghi ThanhToan trạng thái PENDING vào DB
    /// </summary>
    [HttpPost("create-payment-url")]
    public async Task<IActionResult> CreatePaymentUrl([FromBody] PaymentRequestModel model)
    {
        // Kiểm tra xem đơn đã tồn tại chưa
        var existingThanhToan = await _context.ThanhToans.FirstOrDefaultAsync(t => t.MaDon == model.OrderId);
        if (existingThanhToan != null && existingThanhToan.TrangThai == "Success")
        {
            return BadRequest(new { Message = "Đơn hàng này đã được thanh toán rồi." });
        }

        // Lưu hoặc cập nhật thông tin ThanhToan vào DB
        if (existingThanhToan == null)
        {
            var newThanhToan = new ThanhToan
            {
                MaDon = model.OrderId,
                SoTien = (decimal)model.Amount,
                TrangThai = "PENDING",
                NgayTao = DateTime.Now
            };
            _context.ThanhToans.Add(newThanhToan);
        }
        else
        {
            existingThanhToan.SoTien = (decimal)model.Amount;
            existingThanhToan.TrangThai = "PENDING";
            existingThanhToan.NgayTao = DateTime.Now;
        }

        await _context.SaveChangesAsync();

        string tmnCode = _configuration["Vnpay:TmnCode"];
        string hashSecret = _configuration["Vnpay:HashSecret"];
        string baseUrl = _configuration["Vnpay:BaseUrl"];
        string callbackUrl = _configuration["Vnpay:CallbackUrl"];

        var vnpay = new VnPayLibrary();
        vnpay.AddRequestData("vnp_Version", "2.1.0");
        vnpay.AddRequestData("vnp_Command", "pay");
        vnpay.AddRequestData("vnp_TmnCode", tmnCode);
        vnpay.AddRequestData("vnp_Amount", ((long)(model.Amount * 100)).ToString());
        vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
        vnpay.AddRequestData("vnp_CurrCode", "VND");
        
        var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();
        if (string.IsNullOrEmpty(ipAddress) || ipAddress == "::1") ipAddress = "127.0.0.1";
        
        vnpay.AddRequestData("vnp_IpAddr", ipAddress);
        vnpay.AddRequestData("vnp_Locale", "vn");
        vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang " + model.OrderId);
        vnpay.AddRequestData("vnp_OrderType", "other");
        vnpay.AddRequestData("vnp_ReturnUrl", callbackUrl);
        vnpay.AddRequestData("vnp_TxnRef", model.OrderId);

        string paymentUrl = vnpay.CreateRequestUrl(baseUrl, hashSecret);
        return Ok(new { Url = paymentUrl });
    }

    /// <summary>
    /// 2. Return URL (FRONTEND Callback): Query DB để lấy trạng thái thật
    /// </summary>
    [HttpGet("vnpay-return")]
    public async Task<IActionResult> VnpayReturn()
    {
        string hashSecret = _configuration["Vnpay:HashSecret"];
        var vnpay = new VnPayLibrary();

        foreach (var (key, value) in Request.Query)
        {
            if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
            {
                vnpay.AddResponseData(key, value.ToString());
            }
        }

        string vnp_SecureHash = Request.Query["vnp_SecureHash"];
        string maDon = Request.Query["vnp_TxnRef"];
        string vnp_ResponseCode = Request.Query["vnp_ResponseCode"];
        string vnp_TransactionNo = Request.Query["vnp_TransactionNo"];

        bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, hashSecret);
        var thanhToan = await _context.ThanhToans.FirstOrDefaultAsync(t => t.MaDon == maDon);

        if (thanhToan == null)
        {
            return NotFound(new { Message = "Không tìm thấy thông tin thanh toán." });
        }

        if (checkSignature)
        {
            if (vnp_ResponseCode == "00")
            {
                // Cập nhật trạng thái nếu chưa được cập nhật (phòng trường hợp IPN chậm hoặc Localhost)
                if (thanhToan.TrangThai != "Success")
                {
                    thanhToan.TrangThai = "Success";
                    thanhToan.MaGiaoDich = vnp_TransactionNo;
                    thanhToan.NgayThanhToan = DateTime.Now;
                    await _context.SaveChangesAsync();
                }
                return Ok(new { Message = "Thanh toán thành công!", MaDon = thanhToan.MaDon, SoTien = thanhToan.SoTien });
            }
            else
            {
                thanhToan.TrangThai = "FAILED";
                await _context.SaveChangesAsync();
                return BadRequest(new { Message = "Thanh toán thất bại.", Code = vnp_ResponseCode });
            }
        }

        return BadRequest(new { Message = "Sai chữ ký bảo mật VNPAY." });
    }

    /// <summary>
    /// 3. IPN Webhook (BACKEND Callback): Cập nhật PAID hoặc FAILED vào DB
    /// </summary>
    [HttpGet("vnpay-ipn")]
    public async Task<IActionResult> VnpayIpn()
    {
        string hashSecret = _configuration["Vnpay:HashSecret"];
        var vnpay = new VnPayLibrary();

        foreach (var (key, value) in Request.Query)
        {
            if (!string.IsNullOrEmpty(key) && key.StartsWith("vnp_"))
            {
                vnpay.AddResponseData(key, value.ToString());
            }
        }

        string vnp_SecureHash = Request.Query["vnp_SecureHash"];
        bool checkSignature = vnpay.ValidateSignature(vnp_SecureHash, hashSecret);

        if (!checkSignature)
        {
            return Ok(new { RspCode = "97", Message = "Invalid signature" });
        }

        string maDon = vnpay.GetResponseData("vnp_TxnRef");
        string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
        string vnp_TransactionNo = vnpay.GetResponseData("vnp_TransactionNo");

        var thanhToan = await _context.ThanhToans.FirstOrDefaultAsync(t => t.MaDon == maDon);

        if (thanhToan != null && thanhToan.TrangThai == "PENDING")
        {
            if (vnp_ResponseCode == "00")
            {
                thanhToan.TrangThai = "Success";
                thanhToan.MaGiaoDich = vnp_TransactionNo;
                thanhToan.NgayThanhToan = DateTime.Now;
            }
            else
            {
                thanhToan.TrangThai = "FAILED";
            }
            await _context.SaveChangesAsync();
        }

        return Ok(new { RspCode = "00", Message = "Confirm Success" });
    }

    /// <summary>
    /// API Kiểm tra nhanh dữ liệu trong Database
    /// </summary>
    [HttpGet("all-records")]
    public async Task<IActionResult> GetAllRecords()
    {
        var records = await _context.ThanhToans
            .OrderByDescending(t => t.Id)
            .ToListAsync();
        return Ok(records);
    }
}

public class PaymentRequestModel
{
    public string OrderId { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
