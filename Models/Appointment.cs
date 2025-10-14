public class Appointment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int DoctorId { get; set; }
    public int PatientId { get; set; }
    public string? Reason { get; set; }



    public Appointment(int id, DateTime date, int doctorId, int patientId, string? reason)
    {
        Id = id;
        Date = date;
        DoctorId = doctorId;
        PatientId = patientId;
        Reason = reason;
    }

    
}