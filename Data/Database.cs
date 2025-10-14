using testperformance.Models;
namespace testperformance.Data
{
    public static class Database
    {
        public static List<Patient> Patients { get; set; } = new List<Patient>();
        public static List<Doctor> Doctors { get; set; } = new List<Doctor>();
        public static List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}

