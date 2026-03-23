using FluentAssertions;
using ItoApp.Api.Controllers;
using ItoApp.Application.Staff.Dto;
using ItoApp.Domain.Entities;
using ItoApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace ItoApp.Test.Controllers
{
    public class StaffControllerTests : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly StaffController _controller;

        public StaffControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) // Unique DB per test
                .Options;

            _context = new ApplicationDbContext(options);
            _controller = new StaffController(_context);

            SeedDatabase();
        }

        private void SeedDatabase()
        {
            // Seed dependency entities
            var branch = new ChiNhanh 
            { 
                MaChiNhanh = "CN01", 
                TenChiNhanh = "Main Branch", 
                DiaChi = "123 Main St", 
                SoDienThoai = "0123456789" 
            };
            
            var dept = new KhoaPhong 
            { 
                TenKhoaPhong = "IT Dept", 
                MoTa = "IT",
                ChiNhanhId = branch.Id // Will be set after save or consistent if we rely on EF fixup, but better to set if we save separately or together
            };
            // Note: In InMemory, IDs are generated upon Add usually if not set? Or BaseEntity handles it? 
            // BaseEntity usually has Id initialized. Let's assume it does.
            // But we need to link them.
            dept.ChiNhanh = branch; 

            var group = new NhomNgheNghiep 
            { 
                TenNhom = "Engineering Group", 
                MaNhom = "ENG", 
                MoTa = "Engineer" 
            };
            
            var position = new ChucVu 
            { 
                TenChucVu = "Full Stack Dev", 
                MoTa = "Developer" 
            };
            
            _context.ChiNhanhs.Add(branch);
            _context.KhoaPhongs.Add(dept);
            _context.NhomNgheNghieps.Add(group);
            _context.ChucVus.Add(position);
            
            // Seed Staff
            var staff = new NhanVien
            {
                MaNhanVien = "NV001",
                HoTen = "Nguyen Van A",
                NgaySinh = new DateTime(1990, 1, 1),
                GioiTinh = "Nam",
                SoDienThoai = "0123456789",
                Email = "a@example.com",
                DiaChi = "Hanoi",
                NgayVaoLam = DateTime.Now.AddYears(-1),
                TrangThai = "Active",
                ChiNhanhId = branch.Id,
                KhoaPhongId = dept.Id,
                NhomNgheNghiepId = group.Id,
                ChucVuId = position.Id
            };

            _context.NhanViens.Add(staff);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Fact]
        public async Task GetStaff_ShouldReturnAllStaff()
        {
            // Act
            var result = await _controller.GetStaff(null, null, null);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            
            // Serialize to JSON to access anonymous type properties
            var json = System.Text.Json.JsonSerializer.Serialize(okResult.Value);
            var doc = System.Text.Json.JsonDocument.Parse(json);
            
            doc.RootElement.GetProperty("total").GetInt32().Should().Be(1);
        }

        [Fact]
        public async Task GetStaffById_ExistingId_ShouldReturnStaff()
        {
            // Arrange
            var existingStaff = await _context.NhanViens.FirstAsync();

            // Act
            var result = await _controller.GetStaffById(existingStaff.Id);

            // Assert
            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            var dto = okResult.Value.Should().BeOfType<StaffDto>().Subject;
            dto.Id.Should().Be(existingStaff.Id);
            dto.HoTen.Should().Be("Nguyen Van A");
        }

        [Fact]
        public async Task GetStaffById_NonExistingId_ShouldReturnNotFound()
        {
            // Act
            var result = await _controller.GetStaffById();

            // Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task CreateStaff_ValidRequest_ShouldCreateStaff()
        {
            // Arrange
            var branch = await _context.ChiNhanhs.FirstAsync();
            var dept = await _context.KhoaPhongs.FirstAsync();
            var group = await _context.NhomNgheNghieps.FirstAsync();
            var position = await _context.ChucVus.FirstAsync();

            var req = new CreateStaffRequest
            {
                MaNhanVien = "NV002",
                HoTen = "Tran Thi B",
                NgaySinh = new DateTime(1995, 5, 5),
                GioiTinh = "Nu",
                SoDienThoai = "0987654321",
                Email = "b@example.com",
                DiaChi = "HCM",
                NgayVaoLam = DateTime.Now,
                ChiNhanhId = branch.Id,
                KhoaPhongId = dept.Id,
                NhomNgheNghiepId = group.Id,
                ChucVuId = position.Id
            };

            // Act
            var result = await _controller.CreateStaff(req);

            // Assert
            var createdResult = result.Should().BeOfType<CreatedAtActionResult>().Subject;
            var staffId = (Guid)createdResult.Value;

            var dbStaff = await _context.NhanViens.FindAsync(staffId);
            dbStaff.Should().NotBeNull();
            dbStaff.HoTen.Should().Be("Tran Thi B");
            dbStaff.MaNhanVien.Should().Be("NV002");
        }

        [Fact]
        public async Task UpdateStaff_ExistingId_ShouldUpdate()
        {
            // Arrange
            var staff = await _context.NhanViens.FirstAsync();
            var req = new UpdateStaffRequest
            {
                MaNhanVien = staff.MaNhanVien,
                HoTen = "Nguyen Van A Updated",
                NgaySinh = staff.NgaySinh,
                GioiTinh = staff.GioiTinh,
                SoDienThoai = staff.SoDienThoai,
                Email = staff.Email,
                DiaChi = staff.DiaChi,
                NgayVaoLam = staff.NgayVaoLam,
                ChiNhanhId = staff.ChiNhanhId,
                KhoaPhongId = staff.KhoaPhongId,
                NhomNgheNghiepId = staff.NhomNgheNghiepId,
                ChucVuId = staff.ChucVuId
            };

            // Act
            var result = await _controller.UpdateStaff(staff.Id, req);

            // Assert
            result.Should().BeOfType<NoContentResult>();
            
            var updatedStaff = await _context.NhanViens.FindAsync(staff.Id);
            updatedStaff.HoTen.Should().Be("Nguyen Van A Updated");
        }

        [Fact]
        public async Task DeleteStaff_ExistingId_ShouldDelete()
        {
            // Arrange
            var staff = await _context.NhanViens.FirstAsync();

            // Act
            var result = await _controller.DeleteStaff(staff.Id);

            // Assert
            result.Should().BeOfType<NoContentResult>();
            
            var deletedStaff = await _context.NhanViens.FindAsync(staff.Id);
            deletedStaff.Should().BeNull();
        }

        [Fact]
        public async Task UpdateStatus_ShouldChangeStatus()
        {
             // Arrange
            var staff = await _context.NhanViens.FirstAsync();
            var req = new UpdateStaffStatusRequest { TrangThai = "Inactive" };

            // Act
            var result = await _controller.UpdateStatus(staff.Id, req);

            // Assert
             result.Should().BeOfType<NoContentResult>();
             var dbStaff = await _context.NhanViens.FindAsync(staff.Id);
             dbStaff.TrangThai.Should().Be("Inactive");
        }
    }
}

