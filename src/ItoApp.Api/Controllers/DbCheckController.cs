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

        public DbCheckController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetStatus()
        {
            var provider = _configuration.GetValue<string>("DbProvider");
            try
            {
                var canConnect = await _context.Database.CanConnectAsync();
                var dbName = _context.Database.GetDbConnection().Database;
                
                return Ok(new
                {
                    Provider = provider,
                    Status = canConnect ? "Connected Successfully" : "Connection Failed",
                    Database = dbName,
                    ConnectionTest = "OK"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Provider = provider,
                    Status = "Error",
                    Message = ex.Message,
                    InnerException = ex.InnerException?.Message
                });
            }
        }
    }
}
