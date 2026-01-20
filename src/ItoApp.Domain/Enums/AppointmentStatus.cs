namespace ItoApp.Domain.Enums
{
    public enum AppointmentStatus
    {
        Pending = 1,    // Chờ xác nhận
        Confirmed = 2,  // Đã xác nhận
        Cancelled = 3,  // Đã hủy
        Completed = 4,  // Đã khám xong
        NoShow = 5      // Bệnh nhân không đến
    }
}
