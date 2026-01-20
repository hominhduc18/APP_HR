using ItoApp.Domain.Entities;

namespace ItoApp.Domain.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient?> GetByIdAsync(Guid id);
        Task<Patient?> GetByUserIdAsync(Guid userId);
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
    }
}