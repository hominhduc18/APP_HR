namespace ItoApp.Application.Abstractions;

// BEHAVIORAL PATTERN: Strategy
// Định nghĩa các cách xử lý khác nhau (Login vs Register) cho cùng một hành động (Verify OTP).
public interface IOtpStrategy
{
    string StrategyName { get; }
    Task ExecutePostVerificationAsync(string identifier);
}

public class LoginOtpStrategy : IOtpStrategy
{
    public string StrategyName => "Login";
    public async Task ExecutePostVerificationAsync(string identifier)
    {
        // Giả lập logic đăng nhập: tạo JWT, cập nhật LastLogin...
        await Task.CompletedTask;
    }
}

public class RegisterOtpStrategy : IOtpStrategy
{
    public string StrategyName => "Register";
    public async Task ExecutePostVerificationAsync(string identifier)
    {
        // Giả lập logic đăng ký: tạo User, gửi mail chào mừng...
        await Task.CompletedTask;
    }
}
