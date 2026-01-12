using ItoApp.Application.Abstractions;

namespace ItoApp.Infrastructure.Repositories;

public class DevUserRepository : IUserRepository
{
    private static readonly HashSet<string> Phones = new();

    public Task<bool> ExistsByPhoneAsync(string phone)
        => Task.FromResult(Phones.Contains(phone));

    public Task<long> CreatePatientUserAsync(string phone)
    {
        Phones.Add(phone);
        return Task.FromResult(DateTime.UtcNow.Ticks); // demo id
    }
}
