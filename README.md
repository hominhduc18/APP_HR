# 🏥 ItoApp - Premium HR & Hospital Appointment System

[![Build Status](https://img.shields.io/badge/build-passing-brightgreen.svg)](https://dotnet.microsoft.com/download/dotnet/8.0)
[![Framework](https://img.shields.io/badge/framework-.NET%208.0-blue.svg)](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
[![Architecture](https://img.shields.io/badge/architecture-Clean%20Architecture-orange.svg)]()

**ItoApp** is a high-performance, enterprise-grade HR and Hospital management solution. Built with a focus on scalability, modern design aesthetics, and robust domain logic, it provides a seamless experience for both hospital staff and patients.


## 🚀 System Architecture

The project follows **Clean Architecture** principles to ensure maintainability and testability:

- **Domain**: Contains entities, value objects, and core logic (The "Heart").
- **Application**: Business rules, DTOs, and interface definitions.
- **Infrastructure**: Persistence (EF Core), external services (SMS, Mail), and data initialization.
- **API**: Modern REST endpoints with full Swagger documentation and Vietnamese localization.

---

## ✨ Core Modules

### 👨‍💼 1. HR Management (Staff 360)

A comprehensive system to manage hospital personnel, including:

- **Personal Records**: Complete profile with avatars and metadata.
- **Career Lifecycle**: Contracts, promotions, and department transfers.
- **Compliance & Quality**: Professional certificates (CCHN), training history, and disciplinary actions.
- **Dashboard**: Real-time KPI tracking for staff distribution and certificate risks.

### 📅 2. Medical Appointment Booking

A streamlined flow for patients to connect with doctors:

- **Smart Scheduling**: Doctor availability based on branches, specialties, and rooms.
- **Room Management**: Integration with `Dm_PhongBan` for precise physical location tracking.
- **Easy Booking**: Quick registration and booking code generation.

### 🔐 3. Patient Portal

Secure access for medical service users:

- **OTP-based Authentication**: Secure registration and password recovery via SMS simulation.
- **Profile Management**: Update personal info and view booking history.
- **Family Accounts**: (Roadmap) Primary account to manage family members.

### 📊 4. Master Data & Metadata

Standardized lookup tables following international/local medical codes:

- `Dm_DichVu`, `Dm_LoaiDichVu`, `Dm_NhomDichVu`.
- `HospitalBranch`, `Specialty`, `Dm_PhongBan`.

---

## ⚙️ Development Guide

### Prerequisites

- .NET 8.0 SDK
- SQL Server (Developer or LocalDB)
- Optional: SSMS for database inspection

### Quick Setup

1. **Clone & Restore**

   ```bash
   dotnet restore
   ```

2. **Database Migration**

   ```bash
   cd src
   dotnet ef database update --project ItoApp.Infrastructure --startup-project ItoApp.Api
   ```

3. **Run Application**
   ```bash
   dotnet run --project ItoApp.Api
   ```

---

## 🔌 API Reference (Detail Body)

### 🏥 Hospital Master Data (`/api/danh-muc`)

| Endpoint            | Method | Description                               |
| :------------------ | :----- | :---------------------------------------- |
| `/chi-nhanh`        | `GET`  | Get all hospital branches                 |
| `/khoa-phong`       | `GET`  | Get departments, filterable by branchId   |
| `/nhom-nghe-nghiep` | `GET`  | List job categories (Doctor, Nurse, etc.) |
| `/chuc-vu`          | `GET`  | List official positions                   |

### 🔐 Patient Auth Payloads

#### **Request OTP**

`POST /api/patient-auth/request-otp`

```json
{
  "phoneNumber": "0901234567",
  "type": "REGISTER" // OR "FORGOT_PASS"
}
```

#### **Complete Registration**

`POST /api/patient-auth/register`

```json
{
  "phoneNumber": "0901234567",
  "otp": "123456",
  "password": "StrongPassword123!",
  "fullName": "Le Van Tam"
}
```

### 📅 Booking Payloads

#### **Create Appointment**

`POST /api/Hospital/book`

```json
{
  "patientId": "guid-here",
  "doctorId": "guid-here",
  "branchId": "guid-here",
  "scheduleId": "guid-here",
  "reason": "Routine musculoskeletal checkup"
}
```
---

## 🛠 Tech Stack Details

- **Backend**: C#, .NET 8.0, ASP.NET Core Web API.
- **ORM**: Entity Framework Core with SQL Server.
- **Security**: SHA256 Password Hashing, JWT Authentication (Roadmap).
- **Communication**: SMS Service infrastructure for OTP.
- **Data Init**: Automatic seeding of master data on startup.

---

