using ItoApp.Domain.Common;

namespace ItoApp.Domain.Entities
{
     public class Patient : BaseEntity
    {
        public string FullName { get; private set; }
        public DateTime? DateOfBirth { get; private set; } // Đổi từ DateOnly sang DateTime
        public string? Gender { get; private set; }
        public string? Address { get; private set; }
        public string? AvatarUrl { get; private set; }
        public string? EmergencyContact { get; private set; }
        public string? BloodType { get; private set; }
        public string? Allergies { get; private set; }
        public string? MedicalHistory { get; private set; }
        
        // Foreign key
        public Guid UserId { get; private set; }
        
        // Navigation property - QUAN TRỌNG
        public virtual User User { get; private set; } = null!;
        
        // Private constructor for EF Core
        private Patient() {}
        
        // Public constructor
        public Patient(Guid userId, string fullName)
        {
            UserId = userId;
            FullName = ValidateFullName(fullName);
            CreatedAt = DateTime.UtcNow;
        }
        
        public void UpdateProfile(
            string fullName,
            DateTime? dateOfBirth,
            string? gender,
            string? address,
            string? emergencyContact,
            string? bloodType,
            string? allergies,
            string? medicalHistory)
        {
            FullName = ValidateFullName(fullName);
            DateOfBirth = dateOfBirth;
            Gender = gender;
            Address = address;
            EmergencyContact = emergencyContact;
            BloodType = bloodType;
            Allergies = allergies;
            MedicalHistory = medicalHistory;
            
            UpdateTimestamp();
        }
        
        public void UpdateAvatar(string avatarUrl)
        {
            AvatarUrl = avatarUrl;
            UpdateTimestamp();
        }
        
        private string ValidateFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                throw new Domain.Exceptions.DomainException("Full name is required");
                
            var trimmedName = fullName.Trim();
            
            if (trimmedName.Length < 2 || trimmedName.Length > 100)
                throw new Domain.Exceptions.DomainException("Full name must be between 2 and 100 characters");
                
            return trimmedName;
        }
    }
}