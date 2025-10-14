namespace testperformance.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string? Reason { get; set; } = "General Checkup";
        public string? Status { get; set; } = "Scheduled";


        public Appointment() { }
        public Appointment(int id, DateTime date, int doctorId, int patientId, string? reason)
        {
            if (date < DateTime.Now)
                throw new ArgumentException("The date cannot be previous today", nameof(date));

            if (doctorId <= 0)
                throw new ArgumentException("Must be assigned a valid Doctor.", nameof(doctorId));

            if (patientId <= 0)
                throw new ArgumentException("Must be assigned a valid patient.", nameof(patientId));


            Id = id;
            Date = date;
            DoctorId = doctorId;
            PatientId = patientId;
            Reason = string.IsNullOrWhiteSpace(reason) ? "General Checkup" : reason;
        }

        //Method  to update appointment details
        public void UpdateAppointment(DateTime newDate, string? newReason)
        {
            if (newDate < DateTime.Now)
                throw new ArgumentException("The new Date cannot be previous at today.", nameof(newDate));

            Date = newDate;
            Reason = string.IsNullOrWhiteSpace(newReason) ? Reason : newReason;
        }


        public void CancelAppointment()
        {
            Status = "Cancelled";
        }


        public void MarkAsCompleted()
        {
            Status = "Completed";
        }

        public override string ToString()
        {
            return $"Appointment Id: {Id}, Date: {Date}, DoctorId: {DoctorId}, PatientId: {PatientId}, Reason: {Reason}, status: {Status}";
        }
    }
}