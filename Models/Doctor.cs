using testperformance.Models.Enum;

namespace testperformance.Models
{
    public class Doctor
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public Speciality Speciality { get; set; }
        public DocumentType DocumentType { get; set; }
        public string Document { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        //constructor
        public Doctor(Guid id, string name, string lastName, Speciality speciality, DocumentType documentType, string document, string phone, string email, string address)
        {
            Id = id;
            Name = name;
            LastName = lastName;
            Speciality = speciality;
            DocumentType = documentType;
            Document = document;
            Phone = phone;
            Email = email;
            Address = address;
        }


    
        //metodo mostrarinformacion
        public string ShowInformation()
        {
            return $"Doctor: {Name} {LastName}, Specialty: {Speciality}, Document: {DocumentType} {Document}, Phone: {Phone}, Email: {Email}, Address: {Address}";
        }




    }
}