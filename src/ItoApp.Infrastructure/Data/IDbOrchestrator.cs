using Microsoft.EntityFrameworkCore;

namespace ItoApp.Infrastructure.Data
{
    public interface IDbOrchestrator<TContext> where TContext : DbContext
    {
        /// <summary>
        /// Thực thi hành động trên tất cả các database online (dành cho ghi/cập nhật)
        /// </summary>
        Task ExecuteAsync(Func<TContext, Task> action);

        /// <summary>
        /// Truy vấn dữ liệu từ database đầu tiên kết nối được (dành cho đọc)
        /// </summary>
        Task<TResult> QueryAsync<TResult>(Func<TContext, Task<TResult>> query);
    }
}
