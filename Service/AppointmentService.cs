using System;
using System.Collections.Generic;
using System.Linq;
using testperformance.Models;
using testperformance.Interface;
using testperformance.Exceptions;

namespace testperformance.Services
{
    public class AppointmentService
    {
        private readonly IGenericRepository<Appointment> _appointmentRepository;
        private readonly IGenericRepository<Doctor> _doctorRepository;
        private readonly IGenericRepository<Patient> _patientRepository;
        private static int nextId = 1;

        public AppointmentService(
            IGenericRepository<Appointment> appointmentRepository,
            IGenericRepository<Doctor> doctorRepository,
            IGenericRepository<Patient> patientRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _patientRepository = patientRepository;
        }

        // ✅ Agendar una nueva cita
        public void ScheduleAppointment()
        {
            try
            {
                Console.WriteLine(" Ingrese la fecha de la cita (ejemplo: 2025-10-14 15:30):");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    Console.WriteLine(" Fecha inválida.");
                    return;
                }

                Console.WriteLine("👨‍⚕️ Ingrese el ID del médico:");
                if (!int.TryParse(Console.ReadLine(), out int doctorId))
                {
                    Console.WriteLine("ID de médico inválido.");
                    return;
                }

                Console.WriteLine("🧍 Ingrese el ID del paciente:");
                if (!int.TryParse(Console.ReadLine(), out int patientId))
                {
                    Console.WriteLine(" ID de paciente inválido.");
                    return;
                }

                Console.WriteLine("Motivo de la cita:");
                string? reason = Console.ReadLine();

                // Validar existencia de doctor y paciente
                var doctor = _doctorRepository.GetById(doctorId);
                var patient = _patientRepository.GetById(patientId);

                if (doctor == null)
                    throw new NotFoundException("El médico no existe.");
                if (patient == null)
                    throw new NotFoundException("El paciente no existe.");

                // Validar que no existan conflictos de horario
                var appointments = _appointmentRepository.GetAll();
                bool doctorBusy = appointments.Any(a => a.DoctorId == doctorId && a.Date == date);
                bool patientBusy = appointments.Any(a => a.PatientId == patientId && a.Date == date);

                if (doctorBusy)
                    throw new InvalidOperationException("El médico ya tiene una cita en ese horario.");
                if (patientBusy)
                    throw new InvalidOperationException("El paciente ya tiene una cita en ese horario.");

                // Crear nueva cita
                Appointment newAppointment = new Appointment(nextId++, date, doctorId, patientId, reason);
                _appointmentRepository.Add(newAppointment);

                Console.WriteLine($"Cita programada correctamente para el {date} con el Dr. {doctor.Name}.");
            }
            catch (NotFoundException nfEx)
            {
                Console.WriteLine($" {nfEx.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al agendar la cita: {ex.Message}");
            }
        }

        //  Listar todas las citas
        public void ListAppointments()
        {
            var appointments = _appointmentRepository.GetAll().ToList();

            if (!appointments.Any())
            {
                Console.WriteLine("No hay citas registradas.");
                return;
            }

            Console.WriteLine("\n=== LISTA DE CITAS ===");
            foreach (var app in appointments)
            {
                Console.WriteLine($"ID: {app.Id} | Fecha: {app.Date} | Médico ID: {app.DoctorId} | Paciente ID: {app.PatientId} | Motivo: {app.Reason}");
            }
        }

        // 🔍 Buscar citas por ID de paciente
        public void GetAppointmentsByPatient(int patientId)
        {
            var appointments = _appointmentRepository.GetAll().Where(a => a.PatientId == patientId).ToList();

            if (!appointments.Any())
            {
                Console.WriteLine("El paciente no tiene citas registradas.");
                return;
            }

            Console.WriteLine($"Citas del paciente con ID {patientId}:");
            foreach (var app in appointments)
            {
                Console.WriteLine($"🗓️ Fecha: {app.Date} | Motivo: {app.Reason}");
            }
        }

        // Cancelar cita
        public void CancelAppointment(int id)
        {
            var appointment = _appointmentRepository.GetById(id);
            if (appointment == null)
            {
                Console.WriteLine("No se encontró la cita.");
                return;
            }

            _appointmentRepository.Delete(appointment);
            Console.WriteLine("❌ Cita cancelada correctamente.");
        }
    }
}
