namespace ItoApp.Domain.Enums
{
    public enum OtpType
    {
        Register = 1,
        ForgotPassword = 2,
        Login = 3,
        ChangePhone = 4
    }

    public enum OtpChannel
    {
        SMS = 1,
        Email = 2
    }
}