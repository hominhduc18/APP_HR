using ItoApp.Application.Auth.Dto;
using ITOApp.Application.Common;

namespace ItoApp.Application.Interfaces
{



    public interface IPatientAuthService
    {
        // Đăng ký
        Task<BaseResponse<bool>> SendRegisterOtpAsync(SendRegisterOtpRequest request);
        Task<BaseResponse<PatientAuthResponse>> VerifyRegisterOtpAsync(VerifyRegisterOtpRequest request);

        // Đăng nhập
        Task<BaseResponse<PatientAuthResponse>> LoginAsync(PatientLoginRequest request);

        // Quên mật khẩu
        Task<BaseResponse<bool>> SendForgotPasswordOtpAsync(SendForgotPasswordOtpRequest request);
        Task<BaseResponse<bool>> ConfirmForgotPasswordAsync(ConfirmForgotPasswordRequest request);

        // Token
        Task<BaseResponse<PatientAuthResponse>> RefreshTokenAsync(string refreshToken);
        Task<BaseResponse<bool>> LogoutAsync(Guid userId, string refreshToken);
    }
}