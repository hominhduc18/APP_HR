using ItoApp.Domain.Entities.ItoCare;

namespace ItoApp.Application.Interfaces
{
    public interface IItoCareRepository
    {
        // Chi Nhánh
        Task<IEnumerable<ChiNhanh>> GetAllChiNhanhAsync();
        Task<ChiNhanh?> GetChiNhanhByIdAsync(int id);
        
        // Bac Si
        Task<IEnumerable<BacSi>> GetBacSisByChiNhanhAsync(int chiNhanhId);
    }
}
