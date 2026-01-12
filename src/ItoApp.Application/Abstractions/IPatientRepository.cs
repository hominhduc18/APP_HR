namespace ItoApp.Application.Abstractions;

public interface IPatientRepository
{
    Task<long> CreateAsync(long userId);
}