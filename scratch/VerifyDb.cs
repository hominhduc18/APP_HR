using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ItoApp.Infrastructure.Data;
using System.IO;

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("src/ItoApp.Api/appsettings.json")
    .Build();

var services = new ServiceCollection();
var connectionString = configuration.GetConnectionString("Neon");
services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

var serviceProvider = services.BuildServiceProvider();
using var scope = serviceProvider.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

Console.WriteLine("--- KIỂM TRA DỮ LIỆU TRÊN NEON DB ---");
try 
{
    var lastPayments = context.ThanhToans
        .OrderByDescending(t => t.Id)
        .Take(5)
        .ToList();

    if (!lastPayments.Any())
    {
        Console.WriteLine("Bảng ThanhToan đang trống.");
    }
    else 
    {
        foreach (var p in lastPayments)
        {
            Console.WriteLine($"ID: {p.Id} | Mã Đơn: {p.MaDon} | Số Tiền: {p.SoTien} | Trạng Thái: {p.TrangThai} | Tạo Lúc: {p.NgayTao}");
        }
    }
}
catch (Exception ex)
{
    Console.WriteLine($"Lỗi khi truy vấn: {ex.Message}");
}
