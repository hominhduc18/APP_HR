using Microsoft.AspNetCore.Mvc;
using ItoApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ItoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DbCheckController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public DbCheckController(ApplicationDbContext context, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            _context = context;
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }
        [HttpGet("status")]
        public async Task<IActionResult> GetStatus()
        {
            var dbKeys = new[] { "Primary", "Supabase", "Neon" };
            var results = new List<object>();

            foreach (var key in dbKeys)
            {
                var ctx = _serviceProvider.GetKeyedService<ApplicationDbContext>(key);
                if (ctx == null) continue;

                results.Add(await CheckDb(key, ctx));
            }

            return Ok(new
            {
                Timestamp = DateTime.UtcNow,
                Databases = results,
                OrchestratorStatus = "Active"
            });
        }

        private async Task<object> CheckDb(string key, DbContext ctx)
        {
            try
            {
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
                var canConnect = await ctx.Database.CanConnectAsync(cts.Token);
                return new
                {
                    Key = key,
                    Provider = ctx.Database.ProviderName,
                    Status = canConnect ? "Online" : "Offline",
                    Database = ctx.Database.GetDbConnection().Database
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    Key = key,
                    Status = "Error",
                    Message = ex.Message
                };
            }
        }
    }
}

