using testperformance.Interface;
using testperformance.Models.Enum;
using testperformance.Data;
using testperformance.Models;

namespace testperformance.Repositories
{
    // Implementing the IDoctorRepository interface
    public class DoctorRepository : IDoctorRepository 
    
    {
        public void AddDoctor(Doctor doctor)
        {
            Database.Doctors.Add(doctor);
            return;
        }

        public List<Doctor> GetAllBySpecialty(Speciality speciality)
        {
            Enum.TryParse(speciality.ToString(), out Speciality Speciality);
            return Database.Doctors.Where(d => d.Speciality == Speciality).ToList();
        }
        public Doctor? GetById(Guid id)
        {
            return Database.Doctors.FirstOrDefault(d => d.Id == id);
        }
        public bool ExistsByDocument(string document)
        {
            return Database.Doctors.Any(d => d.Document == document);
        }
        public List<Doctor> GetAllDoctors()
        {
            return Database.Doctors;
        }
        public Doctor UpdateDoctor(Doctor doctor)
        {
            var existingDoctor = GetById(doctor.Id);
            if (existingDoctor != null)
            {
                existingDoctor.Name = doctor.Name;
                existingDoctor.LastName = doctor.LastName;
                existingDoctor.Speciality = doctor.Speciality;
                existingDoctor.DocumentType = doctor.DocumentType;
                existingDoctor.Document = doctor.Document;
                existingDoctor.Phone = doctor.Phone;
                existingDoctor.Email = doctor.Email;
                existingDoctor.Address = doctor.Address;
            }
            return existingDoctor!;
        }
        public bool DeleteDoctor(Guid id)
        {
            var doctor = GetById(id);
            if (doctor != null)
            {
                Database.Doctors.Remove(doctor);
                return true;
            }
            return false;
        }
        public Doctor? GetByDocument(string document)
        {
            return Database.Doctors.FirstOrDefault(d => d.Document == document);
        }
    }
}
