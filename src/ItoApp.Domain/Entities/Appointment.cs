using ItoApp.Shared.Common;
using ItoApp.Shared.Enums;

using ItoApp.Shared.Exceptions;
using ItoApp.Shared.Enums;
using ItoApp.Shared.ValueObjects;
using ItoApp.Shared.Common;

namespace ItoApp.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public int PatientId { get; private set; }
        public virtual Patient Patient { get; private set; } = null!;

        public int DoctorId { get; private set; }
        public virtual Doctor Doctor { get; private set; } = null!;

        public int BranchId { get; private set; }
        public virtual HospitalBranch Branch { get; private set; } = null!;

        public DateTime AppointmentDate { get; private set; }
        public TimeSpan AppointmentTime { get; private set; }
        
        public string? Reason { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public string BookingCode { get; private set; }

        private Appointment() { }

        public Appointment(int patientId, int doctorId, int branchId, DateTime date, TimeSpan time, string? reason, string bookingCode)
        {
            PatientId = patientId;
            DoctorId = doctorId;
            BranchId = branchId;
            AppointmentDate = date.Date;
            AppointmentTime = time;
            Reason = reason;
            BookingCode = bookingCode;
            Status = AppointmentStatus.Pending;
            CreatedAt = DateTime.UtcNow;
        }

        public void Confirm()
        {
            Status = AppointmentStatus.Confirmed;
            UpdateTimestamp();
        }

        public void Cancel()
        {
            Status = AppointmentStatus.Cancelled;
            UpdateTimestamp();
        }

        public void Complete()
        {
            Status = AppointmentStatus.Completed;
            UpdateTimestamp();
        }

        public void MarkAsNoShow()
        {
            Status = AppointmentStatus.NoShow;
            UpdateTimestamp();
        }
    }
}



