using ItoApp.Domain.Entities;

namespace ItoApp.Domain.Interfaces
{
    public interface IPatientRepository
    {
        Task<Patient?> GetByIdAsync(int id);
        Task<Patient?> GetByUserIdAsync(int userId);
        Task AddAsync(Patient patient);
        Task UpdateAsync(Patient patient);
    }
}


