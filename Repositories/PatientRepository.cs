using testperformance.Interface;
using testperformance.Models;

namespace testperformance.Repositories
{
    public class patientRepository: GenericRepository<Patient>
    {
        public bool ExistByDocument(string document)
        {
            return _entities.Any(p=> p.Document == document);
        }

        public IEnumerable<Patient> GetByAgeRange(int minAge, int maxAge)
        {
            return _entities.Where(p => p.Age >= minAge && p.Age <= maxAge);
        }
    }

}