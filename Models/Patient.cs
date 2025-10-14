

using testperformance.Interface;


namespace testperformance.Models
{
    public class Patient : Iregister, INotificable
    {
        
        public int Id { get; private set; } 
        public string Document { get; private set; } 
        public string Name { get; private set; } = "UNKNOWN";
        public int Age { get; private set; }
        public string Phone { get; private set; } = "No phone";
        public string Email { get; private set; } = "No email";



        //  BUILDER 


        public Patient(int id, string document, string name, int age, string phone, string email)
        {
            if (string.IsNullOrWhiteSpace(document))
                throw new ArgumentException("The document is mandatory.", nameof(document));

            if (string.IsNullOrWhiteSpace(name))
                name = "UNKNOWN";

            if (age <= 0)
                age = 1;

            Id = id;
            Document = document;
            Name = name;
            Age = age;
            Phone = string.IsNullOrWhiteSpace(phone) ? "No phone" : phone;
            Email = string.IsNullOrWhiteSpace(email) ? "No E-mail" : email;
        }

        // method
        public void UpdateInfo(string name, int age, string phone, string email)
        {
            Name = string.IsNullOrWhiteSpace(name) ? Name : name;
            Age = age > 0 ? age : Age;
            Phone = string.IsNullOrWhiteSpace(phone) ? Phone : phone;
            Email = string.IsNullOrWhiteSpace(email) ? Email : email;
        }

        public void Iregister()
        {
            Console.WriteLine($" Patient Name: {Name} (Document: {Document}) registered succesfully.");
        }

        public void INotificable()
        {
            Console.WriteLine($"Notification to: {Name} (Document: {Document})");
        }

        
    }
}