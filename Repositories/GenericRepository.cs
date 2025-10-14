using System.Collections.Generic;
using System.Linq;
using testperformance.Interface;

namespace testperformance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly List<T> _entities = new();

        public void Add(T entity)
        {
            _entities.Add(entity);
        }

        public void Update(T entity)
        {
            
        }

        public void Delete(T entity)
        {
            _entities.Remove(entity);
        }

        public T GetById(int id)
        {
            var property = typeof(T).GetProperty("Id");
            if (property == null)
                throw new Exception("Entity does not have an Id property");

            return _entities.FirstOrDefault(e => (int)property.GetValue(e)! == id)!;
        }

        public IEnumerable<T> GetAll()
        {
            return _entities;
        }
    }
}