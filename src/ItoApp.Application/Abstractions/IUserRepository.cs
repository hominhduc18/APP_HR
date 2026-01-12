namespace ItoApp.Application.Abstractions;

public interface IUserRepository
{
    Task<bool> ExistsByPhoneAsync(string phone);


    Task<long> CreatePatientUserAsync(string phone);

}