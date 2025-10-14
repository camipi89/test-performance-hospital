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

testperformance
├── /Menus
│   ├── MainMenu.cs            # Menú principal que dirige a los submenús.
│   ├── PatientMenu.cs         # Menú para gestionar pacientes.
│   ├── DoctorMenu.cs          # Menú para gestionar doctores.
│   └── AppointmentMenu.cs     # Menú para gestionar citas médicas.
├── /Service
│   ├── PatientService.cs       # Lógica de negocio para pacientes.
│   ├── DoctorService.cs        # Lógica de negocio para doctores.
│   └── AppointmentService.cs   # Lógica de negocio para citas médicas.
├── /Models
│   ├── Patient.cs              # Modelo de datos para pacientes.
│   ├── Doctor.cs               # Modelo de datos para doctores.
│   └── Appointment.cs            # Modelo de datos para citas médicas.
├── /Interface
│   ├── IGenericRepository.cs     # Interfaz genérica para repositorios.
│   ├── IPatientRepository.cs     # Interfaz específica para pacientes.
│   ├── IDoctorRepository.cs      # Interfaz específica para doctores.
│   └── IAppointmentRepository.cs   # Interfaz específica para citas médicas.
├── /Repositories
│   ├── GenericRepository.cs      # Implementación genérica de repositorios.
│   ├── PatientRepository.cs      # Repositorio específico para pacientes.
│   ├── DoctorRepository.cs       # Repositorio específico para doctores.
│   └── AppointmentRepository.cs    # Repositorio específico para citas médicas.
├── /Exceptions
│   ├── DuplicateRecordException.cs   # Excepción para registros duplicados.
│   ├── NotFoundException.cs          # Excepción para registros no encontrados.
│   └── ValidationException.cs        # Excepción para errores de validación.
├── /Utils
│   ├── DateValidator.cs          # Utilidad para validar fechas.
│   ├── InputHelper.cs            # Métodos para manejar entradas del usuario.
│   └── Logger.cs                 # Utilidad para registrar logs o errores.
└── Program.cs  
# ----------------------------------------------------------------------------------------------------------------------------

Code: 
Camilo Andres Rodriguez Pisciotti 
Equipo: Caiman