

namespace testperformance.Models
{
    public class EmailLog
    {
        public int Id { get; set; }
        public string Recipient { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Body { get; set; } = null!;
        public DateTime SentDate { get; set; }
        public string Status { get; set; } = "Not Sent";
    }
}


