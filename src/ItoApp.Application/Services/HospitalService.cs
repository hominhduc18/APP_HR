using ItoApp.Application.Hospital.Dto;
using ItoApp.Application.Interfaces;
using ItoApp.Domain.Entities;
using ItoApp.Domain.Interfaces;

namespace ItoApp.Application.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly IHospitalRepository _repository;

        public HospitalService(IHospitalRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<BranchDto>> GetBranchesAsync()
        {
            var branches = await _repository.GetAllBranchesAsync();
            return branches.Select(b => new BranchDto(b.Id, b.Name, b.Address, b.PhoneNumber, b.MapUrl));
        }

        public async Task<IEnumerable<SpecialtyDto>> GetSpecialtiesAsync()
        {
            var specialties = await _repository.GetAllSpecialtiesAsync();
            return specialties.Select(s => new SpecialtyDto(s.Id, s.Name, s.Description, s.IconUrl));
        }

        public async Task<IEnumerable<DoctorDto>> GetDoctorsBySpecialtyAsync(int specialtyId)
        {
            var doctors = await _repository.GetDoctorsBySpecialtyAsync(specialtyId);
            return doctors.Select(d => new DoctorDto(d.Id, d.FullName, d.Title, d.Biography, d.AvatarUrl, d.Specialty.Name));
        }

        public async Task<IEnumerable<ScheduleDto>> GetAvailableSchedulesAsync(int doctorId, int branchId, DateTime date)
        {
            var schedules = await _repository.GetDoctorSchedulesAsync(doctorId, branchId, date);
            return schedules
                .Where(s => s.IsActive && s.CurrentPatients < s.MaxPatients)
                .Select(s => new ScheduleDto(s.Id, s.StartTime, s.EndTime, s.MaxPatients - s.CurrentPatients));
        }

        public async Task<AppointmentDto> BookAppointmentAsync(CreateAppointmentRequest request)
        {
            var schedule = await _repository.GetScheduleByIdAsync(request.ScheduleId);
            if (schedule == null || !schedule.IsActive || schedule.CurrentPatients >= schedule.MaxPatients)
                throw new Exception("Schedule not available");

            var bookingCode = GenerateBookingCode();
            
            var appointment = new Appointment(
                request.PatientId,
                request.DoctorId,
                request.BranchId,
                schedule.Date,
                schedule.StartTime,
                request.Reason,
                bookingCode);

            schedule.IncrementPatientCount();
            await _repository.AddAppointmentAsync(appointment);

            return new AppointmentDto(
                appointment.BookingCode,
                schedule.Branch.Name,
                schedule.Doctor.FullName,
                appointment.AppointmentDate,
                appointment.AppointmentTime,
                appointment.Status.ToString());
        }

        public async Task<IEnumerable<AppointmentDto>> GetPatientAppointmentsAsync(int patientId)
        {
            var appointments = await _repository.GetPatientAppointmentsAsync(patientId);
            return appointments.Select(a => new AppointmentDto(
                a.BookingCode,
                a.Branch.Name,
                a.Doctor.FullName,
                a.AppointmentDate,
                a.AppointmentTime,
                a.Status.ToString()));
        }

        private string GenerateBookingCode()
        {
            return "ITO-" + Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
        }
    }
}
