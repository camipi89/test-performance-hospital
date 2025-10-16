
using testperformance.Models;
using testperformance.Models.Enum;

namespace testperformance.Interface
{
    public interface IDoctorRepository
    {
        public void AddDoctor(Doctor doctor);
        List<Doctor> GetAllBySpecialty(Speciality speciality);
        Doctor? GetById(Guid id);
        bool ExistsByDocument(string document);
        List<Doctor> GetAllDoctors();
        public Doctor UpdateDoctor(Doctor doctor);
        public bool DeleteDoctor(Guid id);

        Doctor? GetByDocument(string document);


    }
}