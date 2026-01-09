
   0) BASIC LOOKUP / ENUM (dùng CHECK đơn giản)


-- USERS
CREATE TABLE dbo.Users (
    user_id           BIGINT IDENTITY(1,1) PRIMARY KEY,
    phone             NVARCHAR(20)  NULL,
    email             NVARCHAR(255) NULL,
    password_hash     NVARCHAR(255) NULL,
    full_name         NVARCHAR(200) NOT NULL,
    role              NVARCHAR(20)  NOT NULL,   -- PATIENT/DOCTOR/STAFF/ADMIN
    status            NVARCHAR(20)  NOT NULL DEFAULT 'ACTIVE', -- ACTIVE/LOCKED
    created_at        DATETIME2(0)  NOT NULL DEFAULT SYSDATETIME(),
    updated_at        DATETIME2(0)  NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT UQ_Users_Phone UNIQUE (phone),
    CONSTRAINT UQ_Users_Email UNIQUE (email),
    CONSTRAINT CK_Users_Role CHECK (role IN ('PATIENT','DOCTOR','STAFF','ADMIN')),
    CONSTRAINT CK_Users_Status CHECK (status IN ('ACTIVE','LOCKED'))
);

-- PATIENTS (hồ sơ người bệnh, cho phép 1 user quản lý nhiều người thân)
CREATE TABLE dbo.Patients (
    patient_id        BIGINT IDENTITY(1,1) PRIMARY KEY,
    user_id           BIGINT NULL,
    patient_code      NVARCHAR(50) NULL,
    full_name         NVARCHAR(200) NOT NULL,
    dob               DATE NULL,
    gender            NVARCHAR(10) NULL, -- M/F/O
    id_number         NVARCHAR(30) NULL,
    address           NVARCHAR(500) NULL,
    created_at        DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT UQ_Patients_Code UNIQUE (patient_code),
    CONSTRAINT FK_Patients_User FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id),
    CONSTRAINT CK_Patients_Gender CHECK (gender IS NULL OR gender IN ('M','F','O'))
);

-- DOCTORS
CREATE TABLE dbo.Doctors (
    doctor_id         BIGINT IDENTITY(1,1) PRIMARY KEY,
    user_id           BIGINT NOT NULL,
    license_no        NVARCHAR(50) NULL,
    bio               NVARCHAR(MAX) NULL,
    status            NVARCHAR(20) NOT NULL DEFAULT 'ACTIVE', -- ACTIVE/INACTIVE
    CONSTRAINT UQ_Doctors_User UNIQUE (user_id),
    CONSTRAINT UQ_Doctors_License UNIQUE (license_no),
    CONSTRAINT FK_Doctors_User FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id),
    CONSTRAINT CK_Doctors_Status CHECK (status IN ('ACTIVE','INACTIVE'))
);

-- SPECIALTIES
CREATE TABLE dbo.Specialties (
    specialty_id      BIGINT IDENTITY(1,1) PRIMARY KEY,
    name              NVARCHAR(200) NOT NULL,
    CONSTRAINT UQ_Specialties_Name UNIQUE (name)
);

-- DOCTOR_SPECIALTIES (N-N)
CREATE TABLE dbo.DoctorSpecialties (
    doctor_id         BIGINT NOT NULL,
    specialty_id      BIGINT NOT NULL,
    PRIMARY KEY (doctor_id, specialty_id),
    CONSTRAINT FK_DS_Doctor FOREIGN KEY (doctor_id) REFERENCES dbo.Doctors(doctor_id),
    CONSTRAINT FK_DS_Specialty FOREIGN KEY (specialty_id) REFERENCES dbo.Specialties(specialty_id)
);

-- FACILITIES (cơ sở)
CREATE TABLE dbo.Facilities (
    facility_id       BIGINT IDENTITY(1,1) PRIMARY KEY,
    name              NVARCHAR(200) NOT NULL,
    address           NVARCHAR(500) NULL,
    phone             NVARCHAR(20) NULL
);

-- CLINICS (phòng/đơn vị khám)
CREATE TABLE dbo.Clinics (
    clinic_id         BIGINT IDENTITY(1,1) PRIMARY KEY,
    facility_id       BIGINT NOT NULL,
    name              NVARCHAR(200) NOT NULL,
    type              NVARCHAR(30)  NOT NULL DEFAULT 'OUTPATIENT', -- OUTPATIENT/TELEMED/...
    status            NVARCHAR(20)  NOT NULL DEFAULT 'ACTIVE',     -- ACTIVE/INACTIVE
    CONSTRAINT FK_Clinics_Facility FOREIGN KEY (facility_id) REFERENCES dbo.Facilities(facility_id),
    CONSTRAINT CK_Clinics_Status CHECK (status IN ('ACTIVE','INACTIVE'))
);

-- DOCTOR_CLINICS (N-N)
CREATE TABLE dbo.DoctorClinics (
    doctor_id         BIGINT NOT NULL,
    clinic_id         BIGINT NOT NULL,
    PRIMARY KEY (doctor_id, clinic_id),
    CONSTRAINT FK_DC_Doctor FOREIGN KEY (doctor_id) REFERENCES dbo.Doctors(doctor_id),
    CONSTRAINT FK_DC_Clinic FOREIGN KEY (clinic_id) REFERENCES dbo.Clinics(clinic_id)
);

-- SERVICES (dịch vụ khám)
CREATE TABLE dbo.Services (
    service_id        BIGINT IDENTITY(1,1) PRIMARY KEY,
    name              NVARCHAR(200) NOT NULL,
    price             DECIMAL(18,2) NOT NULL DEFAULT 0,
    duration_minutes  INT NULL,
    active            BIT NOT NULL DEFAULT 1,
    CONSTRAINT UQ_Services_Name UNIQUE (name)
);

/* =========================
   1) SCHEDULE + TIME SLOTS
   ========================= */

-- DOCTOR_SCHEDULES (mỗi ngày/ca)
CREATE TABLE dbo.DoctorSchedules (
    schedule_id       BIGINT IDENTITY(1,1) PRIMARY KEY,
    doctor_id         BIGINT NOT NULL,
    clinic_id         BIGINT NOT NULL,
    work_date         DATE NOT NULL,
    start_time        TIME(0) NOT NULL,
    end_time          TIME(0) NOT NULL,
    slot_minutes      INT NOT NULL DEFAULT 15,
    capacity_per_slot INT NOT NULL DEFAULT 1,
    status            NVARCHAR(20) NOT NULL DEFAULT 'OPEN', -- OPEN/CLOSED
    created_at        DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Schedules_Doctor FOREIGN KEY (doctor_id) REFERENCES dbo.Doctors(doctor_id),
    CONSTRAINT FK_Schedules_Clinic FOREIGN KEY (clinic_id) REFERENCES dbo.Clinics(clinic_id),
    CONSTRAINT CK_Schedules_Time CHECK (end_time > start_time),
    CONSTRAINT CK_Schedules_Status CHECK (status IN ('OPEN','CLOSED')),
    CONSTRAINT CK_Schedules_SlotMinutes CHECK (slot_minutes BETWEEN 5 AND 240),
    CONSTRAINT CK_Schedules_Capacity CHECK (capacity_per_slot >= 1)
);

CREATE INDEX IX_DoctorSchedules_DoctorDate
ON dbo.DoctorSchedules(doctor_id, work_date);

-- TIME_SLOTS (khung giờ cụ thể)
CREATE TABLE dbo.TimeSlots (
    slot_id           BIGINT IDENTITY(1,1) PRIMARY KEY,
    schedule_id       BIGINT NOT NULL,
    slot_start        DATETIME2(0) NOT NULL,
    slot_end          DATETIME2(0) NOT NULL,
    capacity          INT NOT NULL,
    status            NVARCHAR(20) NOT NULL DEFAULT 'AVAILABLE', -- AVAILABLE/FULL/BLOCKED
    created_at        DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_TimeSlots_Schedule FOREIGN KEY (schedule_id) REFERENCES dbo.DoctorSchedules(schedule_id),
    CONSTRAINT CK_TimeSlots_Time CHECK (slot_end > slot_start),
    CONSTRAINT CK_TimeSlots_Capacity CHECK (capacity >= 1),
    CONSTRAINT CK_TimeSlots_Status CHECK (status IN ('AVAILABLE','FULL','BLOCKED'))
);

-- 1 schedule không có 2 slot trùng start
CREATE UNIQUE INDEX UX_TimeSlots_ScheduleStart
ON dbo.TimeSlots(schedule_id, slot_start);

CREATE INDEX IX_TimeSlots_Start
ON dbo.TimeSlots(slot_start);

/* =========================
   2) APPOINTMENTS
   ========================= */

CREATE TABLE dbo.Appointments (
    appointment_id    BIGINT IDENTITY(1,1) PRIMARY KEY,
    patient_id        BIGINT NOT NULL,
    doctor_id         BIGINT NOT NULL,
    clinic_id         BIGINT NOT NULL,
    slot_id           BIGINT NOT NULL,
    service_id        BIGINT NULL,
    reason            NVARCHAR(500) NULL,
    channel           NVARCHAR(20) NOT NULL DEFAULT 'APP', -- APP/CALLCENTER/ONSITE
    status            NVARCHAR(20) NOT NULL DEFAULT 'REQUESTED',
    created_at        DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    confirmed_at      DATETIME2(0) NULL,
    cancelled_at      DATETIME2(0) NULL,
    cancel_reason     NVARCHAR(500) NULL,

    CONSTRAINT FK_Appointments_Patient FOREIGN KEY (patient_id) REFERENCES dbo.Patients(patient_id),
    CONSTRAINT FK_Appointments_Doctor  FOREIGN KEY (doctor_id)  REFERENCES dbo.Doctors(doctor_id),
    CONSTRAINT FK_Appointments_Clinic  FOREIGN KEY (clinic_id)  REFERENCES dbo.Clinics(clinic_id),
    CONSTRAINT FK_Appointments_Slot    FOREIGN KEY (slot_id)    REFERENCES dbo.TimeSlots(slot_id),
    CONSTRAINT FK_Appointments_Service FOREIGN KEY (service_id) REFERENCES dbo.Services(service_id),

    CONSTRAINT CK_Appointments_Channel CHECK (channel IN ('APP','CALLCENTER','ONSITE')),
    CONSTRAINT CK_Appointments_Status CHECK (status IN
        ('REQUESTED','CONFIRMED','CHECKED_IN','COMPLETED','CANCELLED','NO_SHOW'))
);

CREATE INDEX IX_Appointments_Patient
ON dbo.Appointments(patient_id, created_at DESC);

CREATE INDEX IX_Appointments_Doctor
ON dbo.Appointments(doctor_id, created_at DESC);

CREATE INDEX IX_Appointments_Slot
ON dbo.Appointments(slot_id);

-- Nếu bạn muốn "1 slot chỉ 1 lịch hẹn" (capacity=1) thì bật unique này:
-- CREATE UNIQUE INDEX UX_Appointments_Slot_One
-- ON dbo.Appointments(slot_id)
-- WHERE status NOT IN ('CANCELLED');

/* LỊCH SỬ TRẠNG THÁI */
CREATE TABLE dbo.AppointmentStatusHistory (
    id               BIGINT IDENTITY(1,1) PRIMARY KEY,
    appointment_id   BIGINT NOT NULL,
    from_status      NVARCHAR(20) NULL,
    to_status        NVARCHAR(20) NOT NULL,
    changed_by_user_id BIGINT NULL,
    changed_at       DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    note             NVARCHAR(500) NULL,
    CONSTRAINT FK_ASH_Appointment FOREIGN KEY (appointment_id) REFERENCES dbo.Appointments(appointment_id),
    CONSTRAINT FK_ASH_User FOREIGN KEY (changed_by_user_id) REFERENCES dbo.Users(user_id)
);

/* =========================
   3) PAYMENTS + INVOICES
   ========================= */

CREATE TABLE dbo.Payments (
    payment_id       BIGINT IDENTITY(1,1) PRIMARY KEY,
    appointment_id   BIGINT NOT NULL,
    amount           DECIMAL(18,2) NOT NULL,
    method           NVARCHAR(20) NOT NULL, -- CASH/CARD/QR/ONLINE
    provider         NVARCHAR(50) NULL,     -- VNPAY/MOMO/...
    status           NVARCHAR(20) NOT NULL DEFAULT 'PENDING', -- PENDING/PAID/FAILED/REFUNDED
    transaction_ref  NVARCHAR(100) NULL,
    paid_at          DATETIME2(0) NULL,
    created_at       DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Payments_Appointment FOREIGN KEY (appointment_id) REFERENCES dbo.Appointments(appointment_id),
    CONSTRAINT UQ_Payments_Transaction UNIQUE (transaction_ref),
    CONSTRAINT CK_Payments_Method CHECK (method IN ('CASH','CARD','QR','ONLINE')),
    CONSTRAINT CK_Payments_Status CHECK (status IN ('PENDING','PAID','FAILED','REFUNDED'))
);

CREATE INDEX IX_Payments_Appointment
ON dbo.Payments(appointment_id, created_at DESC);

CREATE TABLE dbo.Invoices (
    invoice_id       BIGINT IDENTITY(1,1) PRIMARY KEY,
    payment_id       BIGINT NOT NULL,
    invoice_no       NVARCHAR(50) NOT NULL,
    issued_at        DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    status           NVARCHAR(20) NOT NULL DEFAULT 'ISSUED', -- ISSUED/CANCELLED
    CONSTRAINT FK_Invoices_Payment FOREIGN KEY (payment_id) REFERENCES dbo.Payments(payment_id),
    CONSTRAINT UQ_Invoices_No UNIQUE (invoice_no),
    CONSTRAINT CK_Invoices_Status CHECK (status IN ('ISSUED','CANCELLED'))
);

/* =========================
   4) NOTIFICATIONS + AUDIT LOG
   ========================= */

CREATE TABLE dbo.Notifications (
    notification_id  BIGINT IDENTITY(1,1) PRIMARY KEY,
    user_id          BIGINT NOT NULL,
    type             NVARCHAR(30) NOT NULL, -- REMINDER/CONFIRM/CANCEL/...
    title            NVARCHAR(200) NOT NULL,
    content          NVARCHAR(1000) NOT NULL,
    sent_via         NVARCHAR(20) NOT NULL, -- PUSH/SMS/EMAIL
    sent_at          DATETIME2(0) NULL,
    read_at          DATETIME2(0) NULL,
    created_at       DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    CONSTRAINT FK_Notifications_User FOREIGN KEY (user_id) REFERENCES dbo.Users(user_id),
    CONSTRAINT CK_Notifications_SentVia CHECK (sent_via IN ('PUSH','SMS','EMAIL'))
);

CREATE INDEX IX_Notifications_User
ON dbo.Notifications(user_id, created_at DESC);

CREATE TABLE dbo.AuditLogs (
    audit_id         BIGINT IDENTITY(1,1) PRIMARY KEY,
    actor_user_id    BIGINT NULL,
    action           NVARCHAR(50) NOT NULL,
    entity           NVARCHAR(50) NOT NULL,
    entity_id        NVARCHAR(50) NOT NULL,
    created_at       DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
    metadata_json    NVARCHAR(MAX) NULL,
    CONSTRAINT FK_AuditLogs_User FOREIGN KEY (actor_user_id) REFERENCES dbo.Users(user_id)
);

CREATE INDEX IX_AuditLogs_Entity
ON dbo.AuditLogs(entity, entity_id, created_at DESC);

