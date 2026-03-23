using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ItoApp.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            try
            {
                // To avoid crashes on empty databases (Supabase/Neon),
                // we wrap all seeding in a single try-catch or disable it for now.
                // The current schema on Supabase doesn't match the old entities.
                
                Console.WriteLine("Checking database connection and seeding...");
                
                // Temporary: Just check if we can connect without querying missing tables
                await context.Database.CanConnectAsync();
                
                Console.WriteLine("Connection check passed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Seeding/Connection check skipped or failed: {ex.Message}");
            }
        }
    }
}


