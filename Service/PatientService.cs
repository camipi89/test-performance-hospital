using testperformance.Interface;
using testperformance.Models;

namespace testperformance.Service
{
    public class PatientService
    {
        private readonly IGenericRepository<Patient> _patientRepository;
        private static int nextId = 1;


        public PatientService(IGenericRepository<Patient> patientRepository)
        {
            _patientRepository = patientRepository;
        }



        // register new patient
        public void RegisterPatient()
        {
            try

            {
                Console.WriteLine("Enter the patient's name:");
                string? name = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("The name cannot be empty.");
                    return;
                }

                Console.WriteLine("Enter the patient's document:");
                string? document = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(document))
                {
                    Console.WriteLine("The document is obligatory.");
                    return;
                }

                Console.WriteLine("Enter the age:");
                if (!int.TryParse(Console.ReadLine(), out int age) || age <= 0)
                {
                    Console.WriteLine("Invalid age.");
                    return;
                }


                Console.WriteLine("ENter the phone");
                string? phone = Console.ReadLine();

                Console.WriteLine("enter the email:");
                string? email = Console.ReadLine();

                // validate duplicate document 

                var existingPatient = _patientRepository
                    .GetAll()
                    .FirstOrDefault(p => p.Document == document);

                if (existingPatient != null)
                {
                    Console.WriteLine("A patient with that document already exists.");
                    return;
                }

                var newPatient = new Patient(nextId++, document, name, age, phone ?? "No phone", email ?? "No email");
                _patientRepository.Add(newPatient);

                Console.WriteLine($"THe patient {newPatient.Name} was registered successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering the patient: {ex.Message}");
            }
        }

        // list all patients
        public void ListPatients()
        {
            var patients = _patientRepository.GetAll().ToList();

            if (!patients.Any())
            {
                Console.WriteLine("There is not patietns registered.");
                return;
            }

            Console.WriteLine("\n=== Patients Lists ===");
            foreach (var p in patients)
            {
                Console.WriteLine($"The ID: {p.Id} | The name: {p.Name} | The document: {p.Document} | The Age: {p.Age} | The Phone: {p.Phone} | TheEmail: {p.Email}");
            }
        }

         //  search for ID patient
        public void GetPatientById()
        {
            Console.WriteLine("Increase the patient ID:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(" ID inválid.");
                return;
            }

            var patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                Console.WriteLine(" Patient not found.");
                return;
            }

            Console.WriteLine($"\nPatient found:");
            Console.WriteLine($"ID: {patient.Id}");
            Console.WriteLine($"Name: {patient.Name}");
            Console.WriteLine($"Document: {patient.Document}");
            Console.WriteLine($"Age: {patient.Age}");
            Console.WriteLine($"Phone: {patient.Phone}");
            Console.WriteLine($"Email: {patient.Email}");
        }

        //  Actualizar paciente
        public void UpdatePatient()
        {
            Console.WriteLine("Increse the ID patient to update:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(" ID inválid.");
                return;
            }

            var patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                Console.WriteLine(" Patient not found.");
                return;
            }

            Console.WriteLine($"Updating information of {patient.Name}");

            Console.WriteLine("New name:");
            string? newName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newName))
                patient.Name = newName;

            Console.WriteLine("New Age:");
            string? ageInput = Console.ReadLine();
            if (int.TryParse(ageInput, out int newAge))
                patient.Age = newAge;

            Console.WriteLine("New Phone:");
            string? newPhone = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newPhone))
                patient.Phone = newPhone;

            Console.WriteLine("New email:");
            string? newEmail = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(newEmail))
                patient.Email = newEmail;

            _patientRepository.Update(patient);
            Console.WriteLine(" Patient update successfully.");
        }

        //  Delete patient 
        public void DeletePatient()
        {
            Console.WriteLine("Increase the patient ID to delete:");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine(" ID inválid.");
                return;
            }

            var patient = _patientRepository.GetById(id);
            if (patient == null)
            {
                Console.WriteLine(" Patient not found.");
                return;
            }

            _patientRepository.Delete(patient);
            Console.WriteLine("Patient deleted successfully.");
        }

    }
}