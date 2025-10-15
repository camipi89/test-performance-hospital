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
             _emailService = emailService;
        }

        // schedule new appointment
        public void ScheduleAppointment()
        {
            try
            {
                Console.WriteLine(" Enter the appointment date (example: 2025-10-14 11:11):");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime date))
                {
                    Console.WriteLine(" Invalid Date.");
                    return;
                }

                Console.WriteLine("Enter the ID doctor:");
                if (!int.TryParse(Console.ReadLine(), out int doctorId))
                {
                    Console.WriteLine("ID Doctor inválid.");
                    return;
                }

                Console.WriteLine(" Enter the ID patient:");
                if (!int.TryParse(Console.ReadLine(), out int patientId))
                {
                    Console.WriteLine("inválid ID patient.");
                    return;
                }

                Console.WriteLine("Date reason:");
                string? reason = Console.ReadLine();

                // validate existence of doctor and patient
                var doctor = _doctorRepository.GetById(doctorId);
                var patient = _patientRepository.GetById(patientId);

                if (doctor == null)
                    throw new NotFoundException("The doctor doesn't exist.");
                if (patient == null)
                    throw new NotFoundException("The patient doesn't exist.");

                // Validar que no existan conflictos de horario
                var appointments = _appointmentRepository.GetAll();
                bool doctorBusy = appointments.Any(a => a.DoctorId == doctorId && a.Date == date);
                bool patientBusy = appointments.Any(a => a.PatientId == patientId && a.Date == date);

                if (doctorBusy)
                    throw new InvalidOperationException("The doctor already has an appointment at that time.");
                if (patientBusy)
                    throw new InvalidOperationException("The patient already has an appointment at that time.");

                // Crear nueva cita
                Appointment newAppointment = new Appointment(nextId++, date, doctorId, patientId, reason);
                _appointmentRepository.Add(newAppointment);

                Console.WriteLine($"Appointment scheduled correctly for the {date} with the Dr. {doctor.Name}.");
            }
            catch (NotFoundException Ex)
            {
                Console.WriteLine($" {Ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error scheduling the appointment: {ex.Message}");
            }


        }

        //  List all appointments
        public void ListAppointments()
        {
            var appointments = _appointmentRepository.GetAll().ToList();

            if (!appointments.Any())
            {
                Console.WriteLine("There is not dates registered.");
                return;
            }

            Console.WriteLine("\n=== Dates Lists ===");
            foreach (var app in appointments)
            {
                Console.WriteLine($"The ID: {app.Id} | The Date: {app.Date} | The Doctor ID: {app.DoctorId} | Patient ID: {app.PatientId} | Reason: {app.Reason}");
            }
        }

        // search appointmens by patient id
        public void GetAppointmentsByPatient(int patientId)
        {
            var appointments = _appointmentRepository.GetAll().Where(a => a.PatientId == patientId).ToList();

            if (!appointments.Any())
            {
                Console.WriteLine("The patient have not dates registered.");
                return;
            }

            Console.WriteLine($"Patient Dates by ID {patientId}:");
            foreach (var app in appointments)
            {
                Console.WriteLine($"Date: {app.Date} | Reason: {app.Reason}");
            }
        }

        // Cancel appointment by id 
        public void CancelAppointment(int id)
        {
            var appointment = _appointmentRepository.GetById(id);
            if (appointment == null)
            {
                Console.WriteLine("There are not found dates.");
                return;
            }

            _appointmentRepository.Delete(appointment);
            Console.WriteLine("Date cancelled correctly.");
        }
    }
}
