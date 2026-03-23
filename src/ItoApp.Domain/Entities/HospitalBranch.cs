using ItoApp.Shared.Common;

using ItoApp.Shared.Exceptions;
using ItoApp.Shared.Enums;
using ItoApp.Shared.ValueObjects;
using ItoApp.Shared.Common;

namespace ItoApp.Domain.Entities
{
    public class HospitalBranch : BaseEntity
    {
        public string Name { get; private set; }
        public string Address { get; private set; }
        public string PhoneNumber { get; private set; }
        public string? MapUrl { get; private set; }
        public bool IsActive { get; private set; }

        public virtual ICollection<DoctorSchedule> Schedules { get; private set; } = new List<DoctorSchedule>();
        public virtual ICollection<Appointment> Appointments { get; private set; } = new List<Appointment>();

        private HospitalBranch() { } // For EF Core

        public HospitalBranch(string name, string address, string phoneNumber, string? mapUrl = null)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            MapUrl = mapUrl;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdateInfo(string name, string address, string phoneNumber, string? mapUrl)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            MapUrl = mapUrl;
            UpdateTimestamp();
        }

        public void Deactivate()
        {
            IsActive = false;
            UpdateTimestamp();
        }

        public void Activate()
        {
            IsActive = true;
            UpdateTimestamp();
        }
    }
}



