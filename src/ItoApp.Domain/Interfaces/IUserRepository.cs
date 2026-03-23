using ItoApp.Domain.Entities;

using ItoApp.Shared.Exceptions;
using ItoApp.Shared.Enums;
using ItoApp.Shared.ValueObjects;
using ItoApp.Shared.Common;

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


