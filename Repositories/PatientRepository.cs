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
    }

}