using ItoApp.Domain.Common;
using ItoApp.Domain.Enums;

namespace ItoApp.Domain.Entities
{
    public class Appointment : BaseEntity
    {
        public Guid PatientId { get; private set; }
        public virtual Patient Patient { get; private set; } = null!;

        public Guid DoctorId { get; private set; }
        public virtual Doctor Doctor { get; private set; } = null!;

        public Guid BranchId { get; private set; }
        public virtual HospitalBranch Branch { get; private set; } = null!;

        public DateTime AppointmentDate { get; private set; }
        public TimeSpan AppointmentTime { get; private set; }
        
        public string? Reason { get; private set; }
        public AppointmentStatus Status { get; private set; }
        public string BookingCode { get; private set; }

        private Appointment() { }

        public Appointment(Guid patientId, Guid doctorId, Guid branchId, DateTime date, TimeSpan time, string? reason, string bookingCode)
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
