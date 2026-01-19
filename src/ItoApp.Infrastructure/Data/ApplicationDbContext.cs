using Microsoft.EntityFrameworkCore;
using ItoApp.Domain.Entities;

namespace ItoApp.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<User> Users => Set<User>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<OtpCode> OtpCodes => Set<OtpCode>();
        public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // User configuration
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                // Email value object
                entity.Property(e => e.Email)
                    .HasConversion(
                        v => v != null ? v.Value : null,
                        v => v != null ? Domain.ValueObjects.Email.Create(v) : null)
                    .IsRequired(false)
                    .HasMaxLength(100);
                
                // PhoneNumber value object
                entity.Property(e => e.PhoneNumber)
                    .HasConversion(
                        v => v != null ? v.Value : null,
                        v => v != null ? Domain.ValueObjects.PhoneNumber.Create(v) : null)
                    .IsRequired(false)
                    .HasMaxLength(20);
                
                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);
                
                entity.Property(e => e.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(200);
                
                entity.Property(e => e.ResetPasswordToken)
                    .HasMaxLength(100);
                
                entity.HasIndex(e => e.Email)
                    .IsUnique()
                    .HasFilter("[Email] IS NOT NULL");
                
                entity.HasIndex(e => e.PhoneNumber)
                    .IsUnique()
                    .HasFilter("[PhoneNumber] IS NOT NULL");
                
                entity.Property(e => e.Status)
                    .HasConversion<string>()
                    .HasMaxLength(20);
                
                // One-to-One relationship với Patient
                entity.HasOne(u => u.Patient)
                    .WithOne(p => p.User)
                    .HasForeignKey<Patient>(p => p.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
                    
                // One-to-Many relationship với RefreshTokens
                entity.HasMany(u => u.RefreshTokens)
                    .WithOne(rt => rt.User)
                    .HasForeignKey(rt => rt.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            // Patient configuration
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);
                
                entity.Property(e => e.Gender)
                    .HasMaxLength(10);
                
                entity.Property(e => e.Address)
                    .HasMaxLength(200);
                
                entity.Property(e => e.BloodType)
                    .HasMaxLength(5);
                
                entity.Property(e => e.DateOfBirth)
                    .HasColumnType("date");
                
                // Foreign key to User
                entity.HasOne(p => p.User)
                    .WithOne(u => u.Patient)
                    .HasForeignKey<Patient>(p => p.UserId);
                    
                entity.HasIndex(e => e.UserId)
                    .IsUnique();
            });
            
            // OTP configuration
            modelBuilder.Entity<OtpCode>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Identifier)
                    .IsRequired()
                    .HasMaxLength(100);
                
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(6);
                
                entity.Property(e => e.Type)
                    .HasConversion<string>()
                    .HasMaxLength(20);
                
                entity.Property(e => e.Channel)
                    .HasConversion<string>()
                    .HasMaxLength(10);
                
                entity.HasIndex(e => new { e.Identifier, e.Type, e.CreatedAt });
            });
            
            // RefreshToken configuration
            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(500);
                
                entity.Property(e => e.ReasonRevoked)
                    .HasMaxLength(200);
                
                entity.HasIndex(e => e.Token)
                    .IsUnique();
                
                entity.HasIndex(e => e.UserId);
            });
        }
        
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }
        
        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries<Domain.Common.BaseEntity>();
            
            foreach (var entry in entries)
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Entity.CreatedAt = DateTime.UtcNow;
                }
                else if (entry.State == EntityState.Modified)
                {
                    entry.Entity.UpdatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}