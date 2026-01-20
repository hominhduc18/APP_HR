using ItoApp.Domain.Common;

namespace ItoApp.Domain.Entities
{
    public class Doctor : BaseEntity
    {
        public string FullName { get; private set; }
        public string Title { get; private set; } // BSCKI, ThS, TS...
        public string? Biography { get; private set; }
        public string? AvatarUrl { get; private set; }
        public bool IsActive { get; private set; }

        public Guid SpecialtyId { get; private set; }
        public virtual Specialty Specialty { get; private set; } = null!;

        public virtual ICollection<DoctorSchedule> Schedules { get; private set; } = new List<DoctorSchedule>();
        public virtual ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();

        private Doctor() { }

        public Doctor(string fullName, string title, Guid specialtyId, string? biography = null, string? avatarUrl = null)
        {
            FullName = fullName;
            Title = title;
            SpecialtyId = specialtyId;
            Biography = biography;
            AvatarUrl = avatarUrl;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateProfile(string fullName, string title, Guid specialtyId, string? biography, string? avatarUrl)
        {
            FullName = fullName;
            Title = title;
            SpecialtyId = specialtyId;
            Biography = biography;
            AvatarUrl = avatarUrl;
            UpdateTimestamp();
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdateTimestamp();
        }
    }
}
