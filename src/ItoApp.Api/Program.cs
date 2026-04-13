using ItoApp.Application;
using ItoApp.Infrastructure;
using Scalar.AspNetCore;

// Fix for Npgsql 6.0+ to support local DateTime timestamps
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Clean Architecture Layers
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();

// Configure the port for Cloud environments (Render, etc.)
var port = Environment.GetEnvironmentVariable("PORT") ?? "5271";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// Seed Database
await ItoApp.Infrastructure.Data.DbInitializer.SeedAsync(app.Services);

// Configure the HTTP request pipeline.
// Note: We enable Swagger in Production temporarily for testing deployment
app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ItoApp API V1");
    c.RoutePrefix = "swagger"; // Truy cập tại /swagger
});
app.MapScalarApiReference();

// Nếu bạn muốn bảo mật hơn sau này, hãy đưa app.UseSwagger() vào trong if (app.Environment.IsDevelopment())
if (app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
}
app.UseAuthorization();
app.MapControllers();

app.Run();
