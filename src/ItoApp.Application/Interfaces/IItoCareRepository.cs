using ItoApp.Domain.Entities.ItoCare;

namespace ItoApp.Application.Interfaces
{
    public interface IItoCareRepository
    {
        // Người Dùng
        Task<NguoiDung?> LayNguoiDungTheoSDT(string sdt);
        Task<NguoiDung?> LayNguoiDungTheoId(int id);
        Task ThemNguoiDung(NguoiDung user);
        Task CapNhatNguoiDung(NguoiDung user);

        // Hồ Sơ Bệnh Nhân
        Task<IEnumerable<HoSoBenhNhan>> LayDanhSachHoSoTheoNguoiDung(int nguoiDungId);
        Task<HoSoBenhNhan?> LayHoSoTheoId(int id);
        Task<HoSoBenhNhan?> TimHoSo(string sdt, string ma);
        Task ThemHoSo(HoSoBenhNhan hoSo);
        Task CapNhatHoSo(HoSoBenhNhan hoSo);

        // Chi Nhánh
        Task<IEnumerable<ChiNhanh>> LayTatCaChiNhanh();
        Task<ChiNhanh?> LayChiNhanhTheoId(int id);

        // Khoa Phòng
        Task<IEnumerable<KhoaPhong>> LayDanhSachKhoaTheoChiNhanh(int chiNhanhId);
        
        // Bác Sĩ
        Task<IEnumerable<BacSi>> LayDanhSachBacSi(int chiNhanhId, int khoaId);
        Task<IEnumerable<DateTime>> LayLichTrongBacSi(int bacSiId, DateTime tuNgay);

        // Lịch Hẹn & Khung Giờ
        Task<IEnumerable<KhungGio>> LayDanhSachKhungGio(int bacSiId, DateTime ngay);
        Task<IEnumerable<GoiKham>> LayDanhSachGoiKham();
        Task ThemLichHen(LichHen lichHen);
        Task<IEnumerable<LichHen>> LayDanhSachLichHenTheoNguoiDung(int nguoiDungId);
        Task<LichHen?> LayLichHenTheoId(int id);
        Task CapNhatLichHen(LichHen lichHen);

        // Kết quả CLS
        Task<IEnumerable<KetQuaCls>> LayDanhSachKetQuaTheoHoSo(int hoSoId);
        Task<KetQuaCls?> LayKetQuaTheoId(int id);
    }
}
