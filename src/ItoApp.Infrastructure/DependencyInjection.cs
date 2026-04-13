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

            // 2. Đăng ký Database chính dựa theo cấu hình DbProvider
            var dbProvider = configuration["DbProvider"];
            var neonConn = configuration.GetConnectionString("Neon");
            var sqlServerConn = configuration.GetConnectionString("SqlServer");

            services.AddDbContext<ApplicationDbContext>(options => 
            {
                if (dbProvider == "Postgres" || dbProvider == "Neon")
                {
                    options.UseNpgsql(neonConn);
                }
                else
                {
                    options.UseSqlServer(sqlServerConn);
                }
            });

            // Đăng ký cho các trường hợp đặc biệt (Migration hoặc Orchestration cũ)
            services.AddDbContext<PostgresDbContext>(options => options.UseNpgsql(neonConn));
            services.AddDbContext<SqlDbContext>(options => options.UseSqlServer(sqlServerConn));

            // Vẫn giữ lại Keyed services để không bị lỗi nếu có chỗ nào lỡ dùng, nhưng trỏ về cùng 1 instance
            services.AddKeyedScoped<ApplicationDbContext>("Primary", (sp, key) => sp.GetRequiredService<SqlDbContext>());
            services.AddKeyedScoped<ApplicationDbContext>("Neon", (sp, key) => sp.GetRequiredService<PostgresDbContext>());

            // 2. Đăng ký Database dự phòng (PostgreSQL) - Sử dụng PostgresDbContext
            var supabaseConn = configuration.GetConnectionString("Supabase");
            
            services.AddDbContext<PostgresDbContext>(options => 
            {
                var conn = !string.IsNullOrEmpty(neonConn) ? neonConn : supabaseConn;
                if (!string.IsNullOrEmpty(conn)) options.UseNpgsql(conn);
            });

            if (!string.IsNullOrEmpty(supabaseConn))
            {
                services.AddKeyedScoped<ApplicationDbContext>("Supabase", (sp, key) =>
                {
                    return sp.GetRequiredService<PostgresDbContext>();
                });
            }

            if (!string.IsNullOrEmpty(neonConn))
            {
                services.AddKeyedScoped<ApplicationDbContext>("Neon", (sp, key) =>
                {
                    return sp.GetRequiredService<PostgresDbContext>();
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


