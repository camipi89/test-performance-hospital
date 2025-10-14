namespace testperformance.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Document { get; set; } = null!;
        public string? Name { get; set; }
        public string? Specialty { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }

        public Doctor(int id, string? document, string? name, string? specialty, string? phone, string? email)
        {
             if (string.IsNullOrWhiteSpace(document))
            throw new ArgumentException("the doctor's document is mandatory ", nameof(document));
        
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("the doctor's document is mandatory", nameof(name));
            
            if (string.IsNullOrWhiteSpace(specialty))
                throw new ArgumentException("the doctor's document is mandatory", nameof(specialty));

            if (!string.IsNullOrEmpty(email))
            {
                try { 
                    new System.Net.Mail.MailAddress(email); }
                catch
                   { throw new ArgumentException("Invalid format of email. ", nameof(email)); }
            }

            Id = id;
            Document = document ?? throw new ArgumentNullException(nameof(document));
            Name = name;
            Specialty = specialty;
            Phone = phone;
            Email = email;
        }


    }
}