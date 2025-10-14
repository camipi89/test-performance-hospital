using testperformance.Models;

namespace testperformance.Repositories
{
    public class DoctorRepository : GenericRepository<Doctor>
    {
        public bool ExistsByDocument(string document)
        {
            return _entities.Any(d => d.Document == document);
        }

        public IEnumerable<Doctor> GetBySpecialty(string specialty)
        {
            return _entities.Where(d => d.Specialty?.Equals(specialty, StringComparison.OrdinalIgnoreCase) == true);
        }
    }
}