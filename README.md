# 🏥 APP_HR - ITO App Solution 🚀

Chào mừng bạn đến với **ITO App** - Giải pháp quản lý nhân sự (HR) và Đặt lịch khám bệnh toàn diện, được xây dựng trên nền tảng công nghệ mới nhất.

[![Deploy to Render](https://img.shields.io/badge/Deploy%20to-Render-430098?style=for-the-badge&logo=render&logoColor=white)](https://apiito.onrender.com/swagger)
[![.NET 9](https://img.shields.io/badge/.NET-9.0-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)

---

## 🌟 Tính năng nổi bật

- **Quản lý nhân sự (HR)**: Quản lý hồ sơ nhân viên, bác sĩ, hợp đồng, chứng chỉ hành nghề và kỷ luật.
- **Đặt lịch khám bệnh**: Quy trình đặt lịch thông minh, quản lý ca trực của bác sĩ và chuyên khoa.
- **Thanh toán trực tuyến**: Tích hợp cổng thanh toán **VNPAY**, tự động cập nhật trạng thái đơn hàng.
- **Kiến trúc bền vững**: Xây dựng theo mô hình **Clean Architecture** giúp dễ dàng mở rộng và bảo trì.

---

## 🏗️ Cấu trúc dự án

Dự án được chia thành các lớp (Layers) rõ ràng:
- **`src/ItoApp.Api`**: Cổng kết nối chính (Web API), nơi xử lý Request/Response.
- **`src/ItoApp.Application`**: Nơi chứa Logic nghiệp vụ và các Use Case.
- **`src/ItoApp.Domain`**: Chứa các Entity, định nghĩa cấu trúc dữ liệu cốt lõi.
- **`src/ItoApp.Infrastructure`**: Chứa các phần kết nối bên ngoài (Database Neon, VNPAY, SMS...).

---

## 🌐 Triển khai & Demo

Ứng dụng hiện đang được triển khai trên **Render Cloud** và tự động đồng bộ mỗi khi có code mới.

- **Live API Swagger**: [https://apiito.onrender.com/swagger](https://apiito.onrender.com/swagger)
- **Database**: [Neon PostgreSQL Cloud](https://neon.tech/)

---

## 🛠️ Hướng dẫn chạy nhanh (Local)

1. **Clone project**:
   ```bash
   git clone https://github.com/hominhduc18/APP_HR.git
   ```
2. **Cấu hình**: Cập nhật `ConnectionStrings` và `Vnpay` trong file `appsettings.json`.
3. **Chạy ứng dụng**:
   ```bash
   dotnet run --project src/ItoApp.Api
   ```

---

## 💳 Thông tin Thanh toán (Test)

Bạn có thể test luồng thanh toán VNPAY bằng thông tin thẻ **NCB Sandbox**:
- **Số thẻ**: `9704198526191432198`
- **Tên chủ thẻ**: `NGUYEN VAN A`
- **Ngày phát hành**: `07/15`
- **OTP**: `123456`

---

*Phát triển bởi [hominhduc18](https://github.com/hominhduc18) - 2024*
