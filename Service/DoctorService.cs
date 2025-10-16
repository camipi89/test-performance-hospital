using testperformance.Interface;
using testperformance.Models;
using testperformance.Models.Enum;
using testperformance.Repositories;
using testperformance.Data;

namespace testperformance.Service
{
    public class DoctorService : IDoctorRepository
    {
        private readonly List<Doctor> doctors = new();
        private List<Doctor> _doctors = new();
        private readonly DoctorRepository _doctorRepository = new DoctorRepository();

        public void AddDoctor(Doctor doctor)
        {
            try
            {
                if (_doctorRepository.ExistsByDocument(doctor.Document))
                {
                    Console.WriteLine("A doctor with this document already exists.");
                    return;
                }
                if (doctor == null)
                {
                    throw new ArgumentNullException(nameof(doctor), "Doctor cannot be null");
                }
                if (string.IsNullOrWhiteSpace(doctor.Name) ||
                    string.IsNullOrWhiteSpace(doctor.LastName) ||
                    string.IsNullOrWhiteSpace(doctor.Document) ||
                    string.IsNullOrWhiteSpace(doctor.Email) ||
                    string.IsNullOrWhiteSpace(doctor.Phone) ||
                    string.IsNullOrWhiteSpace(doctor.Address))
                {
                    throw new ArgumentException("Doctor fields cannot be null or empty");
                }
                if (!Enum.IsDefined(typeof(Speciality), doctor.Speciality))
                {
                    throw new ArgumentException("Invalid speciality value", nameof(doctor.Speciality));
                }
                if (!Enum.IsDefined(typeof(DocumentType), doctor.DocumentType))
                {
                    throw new ArgumentException("Invalid document type value", nameof(doctor.DocumentType));
                }
                if (!doctor.Email.Contains("@") || !doctor.Email.Contains("."))
                {
                    throw new ArgumentException("Invalid email format", nameof(doctor.Email));
                }
                if (doctor.Phone.Length < 7 || doctor.Phone.Length > 15 || !doctor.Phone.All(char.IsDigit))
                {
                    throw new ArgumentException("Invalid phone number format", nameof(doctor.Phone));
                }
                //condicion para no poder agregar tipo de dato TI
                if (Enum.Equals(typeof(DocumentType), doctor.DocumentType = DocumentType.TI))
                {
                    throw new ArgumentException("Invalid Documet Type");
                    
                }
                _doctorRepository.AddDoctor(doctor);
                Console.WriteLine("Doctor added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding doctor: {ex.Message}");
            }    

        }
        public List<Doctor> GetAllBySpecialty(Speciality speciality)
        {
            try

            {
                if (_doctorRepository.GetAllBySpecialty(speciality) == null || !_doctorRepository.GetAllBySpecialty(speciality).Any())
                {
                    throw new KeyNotFoundException("No doctors found with the specified specialty.");
                }
                return _doctorRepository.GetAllBySpecialty(speciality);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving doctors by specialty: {ex.Message}");
                return new List<Doctor>();
            }
        }
        public Doctor? GetById(Guid id)
        {
            try

            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("ID cannot be empty", nameof(id));
                }
                if (!Database.Doctors.Any())
                {
                    throw new InvalidOperationException("No doctors available in the database.");
                }
                if (!Database.Doctors.Any(d => d.Id == id))
                {
                    throw new KeyNotFoundException("Doctor with the specified ID does not exist.");
                }
                return Database.Doctors.FirstOrDefault(d => d.Id == id);

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving doctor by ID: {ex.Message}");
                return null;
            }
        }
        public bool ExistsByDocument(string document)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(document))
                {
                    throw new ArgumentException("Document cannot be null or empty", nameof(document));
                }
                if (!Database.Doctors.Any())
                {
                    throw new InvalidOperationException("No doctors available in the database.");
                }
                return Database.Doctors.Any(d => d.Document == document);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error checking document existence: {ex.Message}");
                return false;
            }
        }
        public List<Doctor> GetAllDoctors()
        {
            try
            {
                if (!Database.Doctors.Any())
                {
                    throw new InvalidOperationException("No doctors available in the database.");
                }
                if (Database.Doctors.Count == 0)
                {
                    Console.WriteLine("No doctors registered.");
                    return new List<Doctor>();
                }
                return Database.Doctors;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving all doctors: {ex.Message}");
                return new List<Doctor>();
            }
        }
        public Doctor UpdateDoctor(Doctor doctor)
        {
            try
            {
                if (doctor == null)
                {
                    throw new ArgumentNullException(nameof(doctor), "Doctor cannot be null");
                }
                return _doctorRepository.UpdateDoctor(doctor);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating doctor: {ex.Message}");
                return null!;
            }
        }
        public bool DeleteDoctor(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                {
                    throw new ArgumentException("ID cannot be empty", nameof(id));
                }
                return _doctorRepository.DeleteDoctor(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting doctor: {ex.Message}");
                return false;
            }
        }
        public Doctor? GetByDocument(string document)
        {
            try
            {
                if (_doctorRepository.GetByDocument(document) == null)
                {
                    throw new KeyNotFoundException("Doctor with the specified document does not exist.");
                }
                return _doctorRepository.GetByDocument(document);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving doctor by document: {ex.Message}");
                return null;
            }
        }
    }            

}