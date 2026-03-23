using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ItoApp.Infrastructure.Data
{
    public class DbOrchestrator<TContext> : IDbOrchestrator<TContext> where TContext : DbContext
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<DbOrchestrator<TContext>> _logger;
        private readonly string[] _providerKeys = { "Primary", "Supabase", "Neon" };

        public DbOrchestrator(IServiceProvider serviceProvider, ILogger<DbOrchestrator<TContext>> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task ExecuteAsync(Func<TContext, Task> action)
        {
            var tasks = new List<Task>();

            foreach (var key in _providerKeys)
            {
                var context = _serviceProvider.GetKeyedService<TContext>(key);
                if (context == null) continue;

                tasks.Add(Task.Run(async () =>
                {
                    try
                    {
                        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
                        if (await context.Database.CanConnectAsync(cts.Token))
                        {
                            await action(context);
                            await context.SaveChangesAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning($"Database {key} is unavailable. Error: {ex.Message}");
                    }
                }));
            }

            await Task.WhenAll(tasks);
        }

        public async Task<TResult> QueryAsync<TResult>(Func<TContext, Task<TResult>> query)
        {
            foreach (var key in _providerKeys)
            {
                var context = _serviceProvider.GetKeyedService<TContext>(key);
                if (context == null) continue;

                try
                {
                    using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(2));
                    if (await context.Database.CanConnectAsync(cts.Token))
                    {
                        return await query(context);
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning($"Database {key} query failed. Trying next... Error: {ex.Message}");
                }
            }

            throw new Exception("Tất cả các cơ sở dữ liệu đều không thể kết nối.");
        }
    }
}


