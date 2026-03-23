using ItoApp.Application.Abstractions;
using ItoApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItoApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatternDemoController : ControllerBase
{
    private readonly ISmsSenderFactory _smsFactory;
    private readonly IOtpRepository _otpRepository;
    private readonly IEnumerable<IOtpStrategy> _otpStrategies;

    public PatternDemoController(
        ISmsSenderFactory smsFactory, 
        IOtpRepository otpRepository,
        IEnumerable<IOtpStrategy> otpStrategies)
    {
        _smsFactory = smsFactory;
        _otpRepository = otpRepository;
        _otpStrategies = otpStrategies;
    }

    [HttpGet("creational-factory")]
    public IActionResult TestFactory(string provider = "twilio")
    {
        // FACTORY PATTERN: dynamic resolution
        var sender = _smsFactory.GetSender(provider);
        return Ok(new { 
            Message = "Factory resolved sender", 
            Type = sender.GetType().Name 
        });
    }

    [HttpGet("structural-decorator")]
    public async Task<IActionResult> TestDecorator()
    {
        // DECORATOR PATTERN: The repository here is actually wrapped by LoggingOtpRepositoryDecorator
        // Check console logs to see the "--- [DECORATOR]" output
        await _otpRepository.SaveAsync("demo-user", "Login", "123456", DateTime.Now.AddMinutes(5));
        return Ok(new { 
            Message = "Check console logs to see Decorator in action", 
            RepositoryType = _otpRepository.GetType().Name 
        });
    }

    [HttpGet("behavioral-strategy")]
    public async Task<IActionResult> TestStrategy(string mode = "Login")
    {
        // STRATEGY PATTERN: choose logic based on runtime value
        var strategy = _otpStrategies.FirstOrDefault(s => s.StrategyName == mode);
        if (strategy == null) return BadRequest("Invalid mode");

        await strategy.ExecutePostVerificationAsync("user-123");
        return Ok(new { 
            Message = $"Executed {strategy.StrategyName} strategy", 
            Type = strategy.GetType().Name 
        });
    }
}

