using Microsoft.EntityFrameworkCore;

namespace ItoApp.Infrastructure.Data
{
    public class PostgresDbContext : ApplicationDbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options)
        {
        }
    }
}
