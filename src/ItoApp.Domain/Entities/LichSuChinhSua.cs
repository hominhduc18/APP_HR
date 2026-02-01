using ItoApp.Domain.Common;

namespace ItoApp.Domain.Entities
{
    public class LichSuChinhSua : BaseEntity
    {
        public string ThaoTac { get; set; } = string.Empty; // Thêm mới, Cập nhật, Xóa, Điều chuyển...
        public string NoiDung { get; set; } = string.Empty;
        public string NguoiThucHien { get; set; } = string.Empty;
        public string? DuLieuCu { get; set; } // JSON string
        public string? DuLieuMoi { get; set; } // JSON string

        public Guid? NhanVienId { get; set; }
        public virtual NhanVien? NhanVien { get; set; }
    }
}
