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
            // 1. Đăng ký Database chính (SQL Server)
            var sqlServerConn = configuration.GetConnectionString("SqlServer");
            services.AddKeyedScoped<ApplicationDbContext>("Primary", (sp, key) =>
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(sqlServerConn)
                    .Options;
                return new ApplicationDbContext(options);
            });
            
            // Đăng ký mặc định
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(sqlServerConn));

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
            services.AddScoped<IOtpRepository, OtpRepository>();
            
            // Dynamic SMS Sender registration
            var smsProvider = configuration["Sms:Provider"]?.ToLower();
            var useMock = configuration.GetValue<bool>("Sms:UseMock", true);

            if (useMock || string.IsNullOrEmpty(smsProvider))
            {
                services.AddScoped<ISmsSender, DevSmsSender>();
            }
            else
            {
                switch (smsProvider)
                {
                    case "twilio":
                        services.AddScoped<ISmsSender, TwilioSmsSender>();
                        break;
                    case "viettel":
                        services.AddScoped<ISmsSender, ViettelSmsSender>();
                        break;
                    case "mobifone":
                        services.AddScoped<ISmsSender, MobifoneSmsSender>();
                        break;
                    default:
                        services.AddScoped<ISmsSender, DevSmsSender>();
                        break;
                }
            }

            services.AddScoped<ITokenService, DevTokenService>();

            return services;
        }
    }
}
