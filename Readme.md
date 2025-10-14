#  Medical Appointment Management System

This project is a **C# console application** built with a **layered architecture**, designed to manage **patients**, **doctors**, and **appointments** in a structured way.  
It’s ideal for practicing clean architecture principles such as **separation of concerns**, **repository pattern**, and **basic dependency injection**.

# -----------------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------------------------------------

## Main Features

###  Doctor Management
- Register new doctors with basic information (name, document ID, specialty, phone, and email).
- Edit existing doctor details.
- Validate duplicates by document ID.
- List all registered doctors or filter by specialty.

###  Patient Management
- Register new patients with personal information (name, document ID, age, phone, and email).
- Update existing patient information.
- Validate duplicates by document ID.
- List all registered patients.
###  Appointment Management
- Schedule medical appointments by linking a patient and a doctor with a date and reason.
- Validate that:
  - A doctor cannot have two appointments at the same time.
  - A patient cannot have two appointments at the same time.
- Cancel or mark appointments as completed.
- List appointments by patient or by doctor.

------------------------------------------------------------------------------------------------------

##  Project Architecture

The project follows a **layered architecture** to keep the code modular, maintainable, and scalable:

# Project Structure

/testperformance
├── /Menus
│   ├── MainMenu.cs
│   ├── PatientMenu.cs
│   ├── DoctorMenu.cs
│   └── AppointmentMenu.cs
├── /Service
│   ├── PatientService.cs
│   ├── DoctorService.cs
│   └── AppointmentService.cs
├── /Models
│   ├── Patient.cs
│   ├── Doctor.cs
│   └── Appointment.cs
├── /Interface
│   └── IGenericRepository.cs
└── Program.cs
# ----------------------------------------------------------------------------------------------------------------------------

Code: 
Camilo Andres Rodriguez Pisciotti 
Equipo: Caiman