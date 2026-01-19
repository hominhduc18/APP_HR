using ITOApp.Application.Common;
using ItoApp.Domain;

namespace ItoApp.Application.Interfaces
{



    public interface IOtpService
    {
        Task<BaseResponse<bool>> SendOtpAsync(string identifier, OtpType type);
        Task<BaseResponse<bool>> VerifyOtpAsync(string identifier, string code, OtpType type);
        Task<BaseResponse<bool>> ResendOtpAsync(string identifier, OtpType type);
    }
}