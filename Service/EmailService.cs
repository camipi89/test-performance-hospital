using System.Net;
using System.Net.Mail;
using testperformance.Models;
using testperformance.Interface;

namespace testperformance.Service
{
    public class EmailService
    {
        private readonly IGenericRepository<EmailLog> _emailLogRepository;

        public EmailService(IGenericRepository<EmailLog> emailLogRepository)
        {
            _emailLogRepository = emailLogRepository;
        }

        public void SendEmail(string recipient, string subject, string body)
        {
            var emailLog = new EmailLog
            {
                Id = _emailLogRepository.GetAll().Count() + 1,
                Recipient = recipient,
                Subject = subject,
                Body = body,
                SentDate = DateTime.Now,
                Status = "Not Sent"
            };

            try
            {
                
                Console.WriteLine($"\nSending email to {recipient}...");
                Console.WriteLine($"Subject: {subject}");
                Console.WriteLine($"Body:\n{body}\n");

                

                emailLog.Status = "Sent";
            }
            catch (Exception ex)
            {
                emailLog.Status = $"Not Sent - {ex.Message}";
            }
            finally
            {
                _emailLogRepository.Add(emailLog);
            }
        }

        public void ShowEmailHistory()
        {
            var logs = _emailLogRepository.GetAll();
            Console.WriteLine("\n=== EMAIL LOG HISTORY ===");
            foreach (var log in logs)
            {
                Console.WriteLine($"ID: {log.Id} | To: {log.Recipient} | Status: {log.Status} | Date: {log.SentDate}");
            }
        }
    }
}