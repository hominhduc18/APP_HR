using ItoApp.Domain.Entities;

namespace ItoApp.Domain.Interfaces
{
    public interface IHospitalRepository
    {
        Task<HospitalBranch?> GetBranchByIdAsync(Guid id);
        Task<IEnumerable<HospitalBranch>> GetAllBranchesAsync();
        Task<IEnumerable<Specialty>> GetAllSpecialtiesAsync();
        Task<IEnumerable<Doctor>> GetDoctorsBySpecialtyAsync(Guid specialtyId);
        Task<DoctorSchedule?> GetScheduleByIdAsync(Guid id);
        Task<IEnumerable<DoctorSchedule>> GetDoctorSchedulesAsync(Guid doctorId, Guid branchId, DateTime date);
        
        Task AddAppointmentAsync(Appointment appointment);
        Task<Appointment?> GetAppointmentByCodeAsync(string code);
        Task<IEnumerable<Appointment>> GetPatientAppointmentsAsync(Guid patientId);
    }
}
