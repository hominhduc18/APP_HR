using ItoApp.Domain.Entities;

namespace ItoApp.Domain.Interfaces
{
    public interface IHospitalRepository
    {
        Task<HospitalBranch?> GetBranchByIdAsync(int id);
        Task<IEnumerable<HospitalBranch>> GetAllBranchesAsync();
        Task<IEnumerable<Specialty>> GetAllSpecialtiesAsync();
        Task<IEnumerable<Doctor>> GetDoctorsBySpecialtyAsync(int specialtyId);
        Task<DoctorSchedule?> GetScheduleByIdAsync(int id);
        Task<IEnumerable<DoctorSchedule>> GetDoctorSchedulesAsync(int doctorId, int branchId, DateTime date);
        
        Task AddAppointmentAsync(Appointment appointment);
        Task<Appointment?> GetAppointmentByCodeAsync(string code);
        Task<IEnumerable<Appointment>> GetPatientAppointmentsAsync(int patientId);
    }
}



