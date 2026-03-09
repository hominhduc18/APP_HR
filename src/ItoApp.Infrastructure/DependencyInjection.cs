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
            var provider = configuration.GetValue<string>("DbProvider") ?? "SqlServer";
            var connectionString = configuration.GetConnectionString(provider);
            
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                if (provider == "SqlServer")
                {
                    options.UseSqlServer(connectionString);
                }
                else
                {
                    options.UseNpgsql(connectionString);
                }
            });

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
