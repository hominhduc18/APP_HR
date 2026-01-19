using ItoApp.Domain.Entities;

namespace ItoApp.Domain.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient?> GetByUserIdAsync(Guid userId);
        Task<Patient?> GetByIdAsync(Guid id);
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
    }
}