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

## 💳 Hướng dẫn Test Thanh toán (VNPAY Sandbox)

Để kiểm thử luồng thanh toán, bạn có thể sử dụng các thông tin giả lập sau đây:

### 1. Thẻ ATM Nội địa (Ngân hàng NCB)
| Trường hợp | Số thẻ | Tên chủ thẻ | Ngày phát hành | OTP |
| :--- | :--- | :--- | :--- | :--- |
| **Thành công** | `9704198526191432198` | `NGUYEN VAN A` | `07/15` | `123456` |
| **Hết số dư** | `9704195798459170488` | `NGUYEN VAN A` | `07/15` | `123456` |
| **Thẻ bị khóa** | `9704193370791314` | `NGUYEN VAN A` | `07/15` | `123456` |

### 2. Thẻ Quốc tế (Visa/MasterCard/JCB)
*   **Tên chủ thẻ:** `NGUYEN VAN A`
*   **Ngày hết hạn:** `12/28` (hoặc bất kỳ ngày nào trong tương lai)
*   **CVV/CVC:** `123`

| Loại thẻ | Số thẻ Test |
| :--- | :--- |
| **VISA** | `4456530000001005` |
| **MasterCard** | `5200000000001005` |
| **JCB** | `3337000000000008` |

### 3. VNPAY-QR
*   Khi hiện mã QR, chọn nút **"Giả lập thanh toán"** trên trang Sandbox để hoàn tất mà không cần quét thật.

### 4. API Request mẫu (Body)
Gửi request `POST` đến `/api/payment/create-payment-url`:
```json
{
  "orderId": "DH_1001",
  "amount": 50000
}
```

---


*Phát triển bởi [hominhduc18](https://github.com/hominhduc18) - 2024*
