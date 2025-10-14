using testperformance.Interface;
using testperformance.Models;

namespace testperformance.Service
{
    public class AppointmentService : IGenericRepository<Appointment>
    {
        private readonly List<Appointment> _appointments = new();

        public void Add(Appointment appointment)
        {
            bool doctorBusy = _appointments.Any(a => a.DoctorId == appointment.DoctorId && a.Date == appointment.Date);
            bool patientBusy = _appointments.Any(a => a.PatientId == appointment.PatientId && a.Date == appointment.Date);

            if (doctorBusy)
                throw new InvalidOperationException("The doctor already has an appointment at that time..");

            if (patientBusy)
                throw new InvalidOperationException("The Patient already has an appointment at that time.");

            _appointments.Add(appointment);
        }
        //update appointment
        public void Update(Appointment appointment)
        {
            var existing = GetById(appointment.Id);
            if (existing == null)
                throw new KeyNotFoundException("The date doesn't exist.");

            existing.Date = appointment.Date;
            existing.Reason = appointment.Reason;
            existing.DoctorId = appointment.DoctorId;
            existing.PatientId = appointment.PatientId;
        }

        //delete appointment
        public void Delete(Appointment appointment)
        {
            var existing = GetById(appointment.Id);
            if (existing != null)
                _appointments.Remove(existing);
        }

        // get appointment by id
        public Appointment GetById(int id)
        {
            return _appointments.FirstOrDefault(a => a.Id == id)!;
        }

        public IEnumerable<Appointment> GetAll()
        {
            return _appointments;
        }

        // get appointments by patient by id 
        public IEnumerable<Appointment> GetByPatientId(int patientId)
        {
            return _appointments.Where(a => a.PatientId == patientId);
        }

        // get appointments by doctor by id 
        public IEnumerable<Appointment> GetByDoctorId(int doctorId)
        {
            return _appointments.Where(a => a.DoctorId == doctorId);
        }
    }
}