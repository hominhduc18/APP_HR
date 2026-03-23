using ItoApp.Domain.Interfaces;
using ItoApp.Infrastructure.Data;
using ItoApp.Infrastructure.Repositories;
using ItoApp.Application.Abstractions;
using ItoApp.Infrastructure.Auth;
using ItoApp.Infrastructure.Sms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ItoApp.Application.Interfaces;

namespace ItoApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient();

            // 1. Đăng ký Database chính (SQL Server)
            var sqlServerConn = configuration.GetConnectionString("SqlServer");
            services.AddKeyedScoped<ApplicationDbContext>("Primary", (sp, key) =>
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(sqlServerConn)
                    .Options;
                return new ApplicationDbContext(options);
            });
            
            // Đăng ký mặc định dựa theo cấu hình DbProvider trong appsettings.json
            var dbProvider = configuration["DbProvider"];
            services.AddDbContext<ApplicationDbContext>(options => 
            {
                if (dbProvider == "Neon")
                {
                    options.UseNpgsql(configuration.GetConnectionString("Neon"));
                }
                else if (dbProvider == "Supabase")
                {
                    options.UseNpgsql(configuration.GetConnectionString("Supabase"));
                }
                else
                {
                    options.UseSqlServer(sqlServerConn);
                }
            });

            // 2. Đăng ký Database dự phòng 1 (Supabase - PostgreSQL)
            var supabaseConn = configuration.GetConnectionString("Supabase");
            if (!string.IsNullOrEmpty(supabaseConn))
            {
                services.AddKeyedScoped<ApplicationDbContext>("Supabase", (sp, key) =>
                {
                    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                        .UseNpgsql(supabaseConn)
                        .Options;
                    return new ApplicationDbContext(options);
                });
            }

            // 3. Đăng ký Database dự phòng 2 (Neon - PostgreSQL)
            var neonConn = configuration.GetConnectionString("Neon");
            if (!string.IsNullOrEmpty(neonConn))
            {
                services.AddKeyedScoped<ApplicationDbContext>("Neon", (sp, key) =>
                {
                    var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                        .UseNpgsql(neonConn)
                        .Options;
                    return new ApplicationDbContext(options);
                });
            }

            // 4. Đăng ký Orchestrator
            services.AddScoped(typeof(IDbOrchestrator<>), typeof(DbOrchestrator<>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<IHospitalRepository, HospitalRepository>();
            services.AddScoped<IItoCareRepository, ItoCareRepository>();
            
            // --- STRUCTURAL: Decorator Pattern ---
            // Đăng ký Repository gốc
            services.AddScoped<OtpRepository>(); 
            // Đăng ký Decorator bao bọc Repository gốc
            services.AddScoped<IOtpRepository>(sp => 
            {
                var repo = sp.GetRequiredService<OtpRepository>();
                var logger = sp.GetRequiredService<Microsoft.Extensions.Logging.ILogger<LoggingOtpRepositoryDecorator>>();
                return new LoggingOtpRepositoryDecorator(repo, logger);
            });
            
            // --- CREATIONAL: Factory Pattern ---
            services.AddScoped<DevSmsSender>();
            services.AddScoped<TwilioSmsSender>();
            services.AddScoped<ViettelSmsSender>();
            services.AddScoped<MobifoneSmsSender>();
            services.AddScoped<ISmsSenderFactory, SmsSenderFactory>();

            // Mặc định vẫn đăng ký 1 ISmsSender dựa theo config (nhưng giờ có thể dùng Factory để đổi lúc runtime)
            services.AddScoped<ISmsSender>(sp => 
            {
                var factory = sp.GetRequiredService<ISmsSenderFactory>();
                var provider = configuration["Sms:Provider"] ?? "dev";
                return factory.GetSender(provider);
            });

            // --- BEHAVIORAL: Strategy Pattern ---
            services.AddScoped<IOtpStrategy, LoginOtpStrategy>();
            services.AddScoped<IOtpStrategy, RegisterOtpStrategy>();

            services.AddScoped<ITokenService, DevTokenService>();

            return services;
        }
    }
}


