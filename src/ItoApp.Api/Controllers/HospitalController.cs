using ItoApp.Application.Hospital.Dto;
using ItoApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ItoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HospitalController : ControllerBase
    {
        private readonly IHospitalService _hospitalService;

        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        [HttpGet("branches")]
        public async Task<ActionResult<IEnumerable<BranchDto>>> GetBranches()
        {
            var branches = await _hospitalService.GetBranchesAsync();
            return Ok(branches);
        }

        [HttpGet("specialties")]
        public async Task<ActionResult<IEnumerable<SpecialtyDto>>> GetSpecialties()
        {
            var specialties = await _hospitalService.GetSpecialtiesAsync();
            return Ok(specialties);
        }

        [HttpGet("doctors/{specialtyId}")]
        public async Task<ActionResult<IEnumerable<DoctorDto>>> GetDoctors(Guid specialtyId)
        {
            var doctors = await _hospitalService.GetDoctorsBySpecialtyAsync(specialtyId);
            return Ok(doctors);
        }

        [HttpGet("schedules")]
        public async Task<ActionResult<IEnumerable<ScheduleDto>>> GetSchedules(Guid doctorId, Guid branchId, DateTime date)
        {
            var schedules = await _hospitalService.GetAvailableSchedulesAsync(doctorId, branchId, date);
            return Ok(schedules);
        }

        [HttpPost("book")]
        public async Task<ActionResult<AppointmentDto>> BookAppointment(CreateAppointmentRequest request)
        {
            try
            {
                var appointment = await _hospitalService.BookAppointmentAsync(request);
                return Ok(appointment);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("appointments/{patientId}")]
        public async Task<ActionResult<IEnumerable<AppointmentDto>>> GetPatientAppointments(Guid patientId)
        {
            var appointments = await _hospitalService.GetPatientAppointmentsAsync(patientId);
            return Ok(appointments);
        }
    }
}
