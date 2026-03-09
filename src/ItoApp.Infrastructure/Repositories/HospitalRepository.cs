using ItoApp.Domain.Entities;
using ItoApp.Domain.Interfaces;
using ItoApp.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ItoApp.Infrastructure.Repositories
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly ApplicationDbContext _context;

        public HospitalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<HospitalBranch?> GetBranchByIdAsync(int id)
        {
            return await _context.HospitalBranches.FindAsync(id);
        }

        public async Task<IEnumerable<HospitalBranch>> GetAllBranchesAsync()
        {
            return await _context.HospitalBranches.Where(b => b.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<Specialty>> GetAllSpecialtiesAsync()
        {
            return await _context.Specialties.Where(s => s.IsActive).ToListAsync();
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsBySpecialtyAsync(int specialtyId)
        {
            return await _context.Doctors
                .Include(d => d.Specialty)
                .Where(d => d.SpecialtyId == specialtyId && d.IsActive)
                .ToListAsync();
        }

        public async Task<DoctorSchedule?> GetScheduleByIdAsync(int id)
        {
            return await _context.DoctorSchedules
                .Include(s => s.Doctor)
                .Include(s => s.Branch)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<DoctorSchedule>> GetDoctorSchedulesAsync(int doctorId, int branchId, DateTime date)
        {
            return await _context.DoctorSchedules
                .Where(s => s.DoctorId == doctorId && s.BranchId == branchId && s.Date == date.Date)
                .ToListAsync();
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<Appointment?> GetAppointmentByCodeAsync(string code)
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Branch)
                .FirstOrDefaultAsync(a => a.BookingCode == code);
        }

        public async Task<IEnumerable<Appointment>> GetPatientAppointmentsAsync(int patientId)
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Include(a => a.Branch)
                .Where(a => a.PatientId == patientId)
                .OrderByDescending(a => a.AppointmentDate)
                .ToListAsync();
        }
    }
}
