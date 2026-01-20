using ItoApp.Application.Hospital.Dto;

namespace ItoApp.Application.Interfaces
{
    public interface IHospitalService
    {
        Task<IEnumerable<BranchDto>> GetBranchesAsync();
        Task<IEnumerable<SpecialtyDto>> GetSpecialtiesAsync();
        Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialtyAsync(Guid specialtyId);
        Task<IEnumerable<ScheduleDto>> GetAvailableSchedulesAsync(Guid doctorId, Guid branchId, DateTime date);
        Task<AppointmentDto> BookAppointmentAsync(CreateAppointmentRequest request);
        Task<IEnumerable<AppointmentDto>> GetPatientAppointmentsAsync(Guid patientId);
    }
}
