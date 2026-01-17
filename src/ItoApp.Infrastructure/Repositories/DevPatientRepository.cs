using ItoApp.Application.Abstractions;

namespace ItoApp.Infrastructure.Repositories;


public class DevPatientRepository : IPatientRepository
{
    public Task<long> CreateAsync(long userId)
        => Task.FromResult(DateTime.UtcNow.Ticks); // demo patient id
}
