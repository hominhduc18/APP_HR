using ItoApp.Domain.Entities;

namespace ItoApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(int id);
        Task<User?> GetByEmailAsync(string email);
        Task<User?> GetByPhoneAsync(string phone);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}