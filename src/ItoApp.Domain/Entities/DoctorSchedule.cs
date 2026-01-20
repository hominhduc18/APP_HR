using ItoApp.Domain.Common;

namespace ItoApp.Domain.Entities
{
    public class DoctorSchedule : BaseEntity
    {
        public Guid DoctorId { get; private set; }
        public virtual Doctor Doctor { get; private set; } = null!;

        public Guid BranchId { get; private set; }
        public virtual HospitalBranch Branch { get; private set; } = null!;

        public DateTime Date { get; private set; } // Ngày làm việc
        public TimeSpan StartTime { get; private set; }
        public TimeSpan EndTime { get; private set; }
        
        public int MaxPatients { get; private set; }
        public int CurrentPatients { get; private set; }
        public bool IsActive { get; private set; }

        private DoctorSchedule() { }

        public DoctorSchedule(Guid doctorId, Guid branchId, DateTime date, TimeSpan startTime, TimeSpan endTime, int maxPatients)
        {
            DoctorId = doctorId;
            BranchId = branchId;
            Date = date.Date;
            StartTime = startTime;
            EndTime = endTime;
            MaxPatients = maxPatients;
            CurrentPatients = 0;
            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        public bool IncrementPatientCount()
        {
            if (CurrentPatients >= MaxPatients) return false;
            CurrentPatients++;
            UpdateTimestamp();
            return true;
        }

        public void DecrementPatientCount()
        {
            if (CurrentPatients > 0)
            {
                CurrentPatients--;
                UpdateTimestamp();
            }
        }
    }
}
