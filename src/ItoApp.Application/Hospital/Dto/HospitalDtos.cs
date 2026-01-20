namespace ItoApp.Application.Hospital.Dto
{
    public record BranchDto(Guid Id, string Name, string Address, string PhoneNumber, string? MapUrl);
    public record SpecialtyDto(Guid Id, string Name, string? Description, string? IconUrl);
    public record DoctorDto(Guid Id, string FullName, string Title, string? Biography, string? AvatarUrl, string SpecialtyName);
    public record ScheduleDto(Guid Id, TimeSpan StartTime, TimeSpan EndTime, int RemainingSlots);
    
    public record CreateAppointmentRequest(
        Guid PatientId,
        Guid DoctorId,
        Guid BranchId,
        Guid ScheduleId,
        string? Reason);

    public record AppointmentDto(
        string BookingCode,
        string HospitalName,
        string DoctorName,
        DateTime Date,
        TimeSpan Time,
        string Status);
}
