# ItoApp - HR & Hospital Appointment System

This is a comprehensive HR and Hospital management system built with **.NET 8** and **Clean Architecture**. It features Staff Management (HR), Patient Registration, Appointment Booking, and more.

## 🚀 Overview

The system handles:

- **HR Management**: Manage staff, departments, positions (Staff, Doctors, etc.).
- **Authentication**: Login/Register for Patients (with OTP support).
- **Hospital Operations**: Branch management, Specialties, Doctor schedules.
- **Appointments**: Booking, viewing, and managing patient appointments.

## ⚙️ Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (or LocalDB)

### Build & Run

```bash
# Build
dotnet build
# Run API
dotnet run --project ItoApp.Api
# Run Tests
dotnet test
```

## 🔌 API Reference & Payloads

Below is the detailed list of available API endpoints and their Request Body structures.

### 1. 🏥 HR - Staff Management (`/api/nhan-vien`)

**Create Staff** (`POST /api/nhan-vien`)

```json
{
  "maNhanVien": "NV001",
  "hoTen": "Nguyen Van A",
  "ngaySinh": "1990-01-01T00:00:00Z",
  "gioiTinh": "Nam",
  "soDienThoai": "0987654321",
  "email": "a@example.com",
  "diaChi": "TP.HCM",
  "ngayVaoLam": "2023-01-01T00:00:00Z",
  "chiNhanhId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "khoaPhongId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "nhomNgheNghiepId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "chucVuId": "3fa85f64-5717-4562-b3fc-2c963f66afa6"
}
```

**Update Staff** (`PUT /api/nhan-vien/{id}`)
_Same body as Create Staff_

**Change Status** (`PATCH /api/nhan-vien/{id}/trang-thai`)

```json
{
  "trangThai": "Inactive"
}
```

**Transfer Dept** (`POST /api/nhan-vien/{id}/dieu-chuyen`)

```json
{
  "newKhoaPhongId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "effectiveDate": "2024-02-01T00:00:00Z",
  "reason": "Job rotation"
}
```

---

### 2. � Staff Profile (`/api/nhan-vien/{staffId}`)

**Add Contract** (`POST .../hop-dong`)

```json
{
  "soHopDong": "HD-2024-001",
  "loaiHopDong": "Official",
  "ngayKy": "2024-01-01T00:00:00Z",
  "ngayHetHan": "2025-01-01T00:00:00Z",
  "duongDanFileScan": "http://example.com/scan.pdf"
}
```

**Add License (CCHN)** (`POST .../chung-chi-hanh-nghe`)

```json
{
  "soChungChi": "CCHN-00123",
  "phamViChuyenMon": "General Medicine",
  "noiCap": "Department of Health",
  "ngayCap": "2020-01-01T00:00:00Z",
  "ngayGiaHan": "2025-01-01T00:00:00Z",
  "ngayHetHan": "2025-12-31T00:00:00Z"
}
```

**Add Training** (`POST .../dao-tao`)

```json
{
  "tenChungChi": "CPR Certification",
  "noiDaoTao": "Red Cross",
  "ngayHoanThanh": "2023-06-15T00:00:00Z",
  "ngayHetHan": "2025-06-15T00:00:00Z"
}
```

**Add Professional Privilege** (`POST .../ky-thuat-chuyen-mon`)

```json
{
  "tenKyThuat": "Appendectomy",
  "soQuyetDinh": "QD-1234",
  "ngayPheDuyet": "2023-01-01T00:00:00Z",
  "moTa": "Level 1 Surgery"
}
```

**Add Discipline** (`POST .../ky-luat`)

```json
{
  "hinhThuc": "Warning",
  "lyDo": "Late arrival",
  "ngayViPham": "2024-01-10T00:00:00Z",
  "soQuyetDinh": "QD-KL-001",
  "ngayQuyetDinh": "2024-01-12T00:00:00Z"
}
```

---

### 3. �🔐 Authentication (Patient)

**Login (Send OTP)** (`POST /api/auth/login`)

```json
{ "phone": "0909000111" }
```

**Verify Login** (`POST /api/auth/verify`)

```json
{
  "phone": "0909000111",
  "otp": "123456"
}
```

**Register (Send OTP)** (`POST /api/patient/register/otp/send`)

```json
{ "phone": "0909000111" }
```

**Register (Complete)** (`POST /api/patient/register/otp/verify`)

```json
{
  "phone": "0909000111",
  "otp": "123456",
  "fullName": "Tran Van B",
  "password": "Password123"
}
```

**Refresh Token** (`POST /api/auth/refresh`)

```json
{
  "refreshToken": "your_refresh_token_string"
}
```

---

### 4. 🏥 Hospital & Booking (`/api/Hospital`)

**Book Appointment** (`POST /api/Hospital/book`)

```json
{
  "patientId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "doctorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "branchId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "scheduleId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
  "reason": "Headache checkup"
}
```

**Get Schedules** (`GET /api/Hospital/schedules`)
Query Params: `doctorId`, `branchId`, `date` (YYYY-MM-DD)

---

### 5. � Patient Profile (`/api/patient`)

**Update Profile** (`PUT /api/patient/{id}`)

```json
{
  "name": "Tran Van B Updated",
  "birthDate": "1995-05-20T00:00:00Z"
}
```

### 6. 💳 Payment Integration (VNPAY)

The system is integrated with **VNPAY Sandbox** for processing medical fees and appointments.

- **Create Payment URL** (`POST /api/payment/create-payment-url`)
- **VNPAY Return Callback** (`GET /api/payment/vnpay-return`)
- **Database Verification** (`GET /api/payment/all-records`)

#### 💳 Test Card Information (NCB Bank)
| Field | Value |
| :--- | :--- |
| **Bank** | NCB |
| **Card Number** | `9704198526191432198` |
| **Card Holder** | `NGUYEN VAN A` |
| **Issue Date** | `07/15` |
| **OTP** | `123456` |

---

## 📊 Analytics & Metadata

- **Dashboard**: `GET /api/thong-ke/chi-so-kpi`, `/api/thong-ke/bieu-do/*`
- **Metadata**: `GET /api/danh-muc/chi-nhanh`, `/api/danh-muc/khoa-phong`, etc.
- **Reports**: `GET /api/bao-cao/ho-so-360/{id}`, `/api/bao-cao/danh-sach-ru-ro-chung-chi`, etc.

---

_Generated by Antigravity Assistant_
