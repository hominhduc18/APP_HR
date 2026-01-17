using ItoApp.Application.Auth.Dto;
using ItoApp.Application.Auth.Register;
using Microsoft.AspNetCore.Mvc;

namespace ItoApp.Api.Controllers;



[ApiController]
[Route("api/patient/register")]
public class PatientRegisterController : ControllerBase
{
    private readonly RegisterService _service;
    public PatientRegisterController(RegisterService service) => _service = service;

    [HttpPost("otp/send")]
    public async Task<IActionResult> SendOtp([FromBody] RegisterSendOtpRequest req)
        => Ok(await _service.SendOtpAsync(req));

    [HttpPost("otp/verify")]
    public async Task<IActionResult> VerifyOtp([FromBody] RegisterVerifyOtpRequest req)
        => Ok(await _service.VerifyOtpAsync(req));
}
