namespace ItoApp.Application.Hospital.Dto
{
    public record BranchDto(int Id, string Name, string Address, string PhoneNumber, string? MapUrl);
    public record SpecialtyDto(int Id, string Name, string? Description, string? IconUrl);
    public record DoctorDto(int Id, string FullName, string Title, string? Biography, string? AvatarUrl, string SpecialtyName);
    public record ScheduleDto(int Id, TimeSpan StartTime, TimeSpan EndTime, int RemainingSlots);
    
    public record CreateAppointmentRequest(
        int PatientId,
        int DoctorId,
        int BranchId,
        int ScheduleId,
        string? Reason);

    public record AppointmentDto(
        string BookingCode,
        string HospitalName,
        string DoctorName,
        DateTime Date,
        TimeSpan Time,
        string Status);
}
