using ItoApp.Application.Hospital.Dto;

namespace ItoApp.Application.Interfaces
{
    public interface IHospitalService
    {
        Task<IEnumerable<BranchDto>> GetBranchesAsync();
        Task<IEnumerable<SpecialtyDto>> GetSpecialtiesAsync();
        Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialtyAsync(int specialtyId);
        Task<IEnumerable<ScheduleDto>> GetAvailableSchedulesAsync(int doctorId, int branchId, DateTime date);
        Task<AppointmentDto> BookAppointmentAsync(CreateAppointmentRequest request);
        Task<IEnumerable<AppointmentDto>> GetPatientAppointmentsAsync(int patientId);
    }
}
