using Microsoft.AspNetCore.Mvc;
using ItoApp.Api.Helpers;

namespace ItoApp.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaymentController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public PaymentController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// 1. Tạo URL thanh toán qua VNPAY (Frontend sẽ dùng URL này để redirect người dùng)
    /// </summary>
    /// <param name="model">Bao gồm mã đơn hàng (OrderId) và số tiền (Amount)</param>
    [HttpPost("create-payment-url")]
    public IActionResult CreatePaymentUrl([FromBody] PaymentRequestModel model)
    {
        string tmnCode = _configuration["Vnpay:TmnCode"];
        string hashSecret = _configuration["Vnpay:HashSecret"];
        string baseUrl = _configuration["Vnpay:BaseUrl"];
        string callbackUrl = _configuration["Vnpay:CallbackUrl"];

        var vnpay = new VnPayLibrary();
        vnpay.AddRequestData("vnp_Version", "2.1.0");
        vnpay.AddRequestData("vnp_Command", "pay");
        vnpay.AddRequestData("vnp_TmnCode", tmnCode);
        vnpay.AddRequestData("vnp_Amount", (model.Amount * 100).ToString());
        vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
        vnpay.AddRequestData("vnp_CurrCode", "VND");
        vnpay.AddRequestData("vnp_IpAddr", HttpContext.Connection.RemoteIpAddress?.ToString() ?? "127.0.0.1");
        vnpay.AddRequestData("vnp_Locale", "vn");
        vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang " + model.OrderId);
        vnpay.AddRequestData("vnp_OrderType", "other");
        vnpay.AddRequestData("vnp_ReturnUrl", callbackUrl);
        vnpay.AddRequestData("vnp_TxnRef", DateTime.Now.Ticks.ToString()); 

        string paymentUrl = vnpay.CreateRequestUrl(baseUrl, hashSecret);
        return Ok(new { Url = paymentUrl });
    }

    /// <summary>
    /// 2. Return URL (FRONTEND Callback): Nơi VNPAY điều hướng về sau khi khách thanh toán xong.
    /// Dùng API này để show màn hình "Thành công / Thất bại" ra cho khách chứ KHÔNG dùng để cập nhật kết quả vào DB.
    /// </summary>
    [HttpGet("vnpay-return")]
    public IActionResult VnpayReturn()
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

        if (checkSignature)
        {
            string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            string orderId = vnpay.GetResponseData("vnp_TxnRef");
            
            if (vnp_ResponseCode == "00")
            {
                return Ok(new { Message = "Thanh toán thành công!", OrderId = orderId });
            }
            return BadRequest(new { Message = "Thanh toán giao dịch thất bại.", ErrorCode = vnp_ResponseCode });
        }
        else
        {
            return BadRequest(new { Message = "Sai chữ ký VNPAY bảo mật!" });
        }
    }

    /// <summary>
    /// 3. IPN Webhook (BACKEND Callback): Server VNPAY gọi ngầm vào để chốt doanh thu. 
    /// Dùng API này để kiếm tra chữ ký và cập nhật File Data/Database sang trạng thái "Đã thanh toán".
    /// </summary>
    [HttpGet("vnpay-ipn")]
    public IActionResult VnpayIpn()
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

        if (checkSignature)
        {
            string vnp_ResponseCode = vnpay.GetResponseData("vnp_ResponseCode");
            if (vnp_ResponseCode == "00")
            {
                 // Thanh toán thành công, update DB
                 return Ok(new { RspCode = "00", Message = "Confirm Success" });
            }
            return Ok(new { RspCode = "00", Message = "Thanh toán thất bại" });
        }
        else
        {
            return Ok(new { RspCode = "97", Message = "Invalid signature" });
        }
    }
}

public class PaymentRequestModel
{
    public string OrderId { get; set; } = string.Empty;
    public double Amount { get; set; }
}
