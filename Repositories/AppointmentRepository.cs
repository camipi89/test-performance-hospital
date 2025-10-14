using testperformance.Models;

namespace testperformance.Repositories
{
    public class AppointmentRepository : GenericRepository<Appointment>
    {
        public bool HasAppointmentConflict(int doctorId, DateTime date)
        {
            return _entities.Any(a => a.DoctorId == doctorId && a.Date == date);
        }

        public bool PatientHasConflict(int patientId, DateTime date)
        {
            return _entities.Any(a => a.PatientId == patientId && a.Date == date);
        }

        public IEnumerable<Appointment> GetByPatient(int patientId)
        {
            return _entities.Where(a => a.PatientId == patientId);
        }

        public IEnumerable<Appointment> GetByDoctor(int doctorId)
        {
            return _entities.Where(a => a.DoctorId == doctorId);
        }
    }
}