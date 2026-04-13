using Microsoft.EntityFrameworkCore;

namespace ItoApp.Infrastructure.Data
{
    public class SqlDbContext : ApplicationDbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {
        }
    }
}
