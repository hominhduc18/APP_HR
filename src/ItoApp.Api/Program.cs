using ItoApp.Application.Abstractions;
using ItoApp.Application.Auth.Register;
using ItoApp.Infrastructure.Auth;
using ItoApp.Infrastructure.Repositories;
using ItoApp.Infrastructure.Sms;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// ✅ Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<RegisterService>();

// DEV repos (user/patient)
builder.Services.AddScoped<IUserRepository, DevUserRepository>();
builder.Services.AddScoped<IPatientRepository, DevPatientRepository>();

// OTP repo dùng SQL thật
var cs = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IOtpRepository>(_ => new SqlOtpRepository(cs!));

// external services
builder.Services.AddScoped<ISmsSender, DevSmsSender>();
builder.Services.AddScoped<ITokenService, DevTokenService>();

var app = builder.Build();

// ✅ Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();