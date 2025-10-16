using testperformance.Interface;
using testperformance.Models;
using System.Collections.Generic;
using System.Linq;

namespace testperformance.Repositories
{
    public class EmailLogRepository : IGenericRepository<EmailLog>
    {
        private readonly List<EmailLog> _logs = new();

        public void Add(EmailLog entity) => _logs.Add(entity);

        public void Delete(EmailLog entity) => _logs.Remove(entity);

        public IEnumerable<EmailLog> GetAll() => _logs;

        public EmailLog GetById(int id) => _logs.FirstOrDefault(l => l.Id == id)!;

        public void Update(EmailLog entity)
        {
            var index = _logs.FindIndex(l => l.Id == entity.Id);
            if (index >= 0) _logs[index] = entity;
        }

        public IEnumerable<EmailLog> GetByRecipient(string recipient)
        {
            return _logs.Where(l => l.Recipient?.Equals(recipient, StringComparison.OrdinalIgnoreCase) == true);
        }
    }
}