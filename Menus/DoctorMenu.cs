using System;
using testperformance.Repositories;
using testperformance.Models;
using testperformance.Service;
using testperformance.Models.Enum;
using System.Net.Http.Headers;

namespace testperformance.Menus
{
    public static class DoctorMenu
    {
        private static readonly DoctorService _service = new();
        public static readonly DoctorRepository _doctorRepository = new DoctorRepository();

        running = true;



        public static void Show()
        {
            while (running)
            {
                Console.Clear();
                Console.WriteLine("===== DOCTOR MENU =====");
                Console.WriteLine("1. Register Doctor");
                Console.WriteLine("2. List All Doctors");
                Console.WriteLine("3. Search Doctor by ID");
                Console.WriteLine("4. Update Doctor");
                Console.WriteLine("5. Delete Doctor");
                Console.WriteLine("6. List Doctors by Specialty");
                Console.WriteLine("0. Return to Main Menu");
                Console.Write("\nSelect an option: ");

                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("===== Register New Doctor =====");
                        Console.Write("Enter Name: ");
                        string? name = Console.ReadLine();
                        Console.Write("Enter Last Name: ");
                        string? lastName = Console.ReadLine();
                        Console.Write("Enter Specialty ");
                        // Mostrar las especialidades con números para que el usuario elija
                        int index = 1; // Empieza en 1 para que sea más amigable
                        foreach (Speciality esp in Enum.GetValues(typeof(Speciality)))
                        {
                            Console.WriteLine($"{index}. {esp}");
                            index++;
                        }

                        // Ahora, leer la opción del usuario (número)
                        Console.Write("Selecciona una especialidad por número: ");
                        bool isValid = int.TryParse(Console.ReadLine(), out int selectedNumber);

                        if (isValid && selectedNumber >= 1 && selectedNumber <= Enum.GetValues(typeof(Speciality)).Length)
                        {
                            Speciality selectedSpeciality = (Speciality)Enum.GetValues(typeof(Speciality)).GetValue(selectedNumber - 1);

                            Console.WriteLine($"Seleccionaste: {selectedSpeciality}");
                        }
                        

                        else
                        {
                            Console.WriteLine("Opción inválida.");
                        }
                        Console.Write("Enter Document Type");
                        int docT = 1;
                        foreach (DocumentType doc in Enum.GetValues(typeof(DocumentType)))
                        {
                            Console.WriteLine($"{docT}. {doc}");
                            docT++;
                        }
                        Console.Write("Select a document type by number: ");
                        bool isDocValid = int.TryParse(Console.ReadLine(), out int selectedDocNumber);
                        if (isDocValid && selectedDocNumber >= 1 && selectedDocNumber <= Enum.GetValues(typeof(DocumentType)).Length)
                        {
                            DocumentType selectedDocType = (DocumentType)Enum.GetValues(typeof(DocumentType)).GetValue(selectedDocNumber - 1);
                            Console.WriteLine($"You selected: {selectedDocType}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid option.");
                        }
                        Console.Write("Enter Document Number: ");
                        string? documentNumber = Console.ReadLine();
                        Console.Write("Enter Phone Number: ");
                        string? phoneNumber = Console.ReadLine();
                        Console.Write("Enter Email: ");
                        string? email = Console.ReadLine();
                        Console.Write("Enter Address: ");
                        string? address = Console.ReadLine();
                        Doctor newDoctor = new(Guid.NewGuid(), name!, lastName!, selectedSpeciality, selectedDocType, documentNumber!, phoneNumber!, email!, address!);
                        _service.AddDoctor(newDoctor);
                        Console.WriteLine("Doctor registered successfully!");
                        Console.WriteLine("Press Enter to continue...");
                        Console.ReadLine();
                        break;

                //     case "2":
                //         _service.ListDoctors();
                //         break;
                //     case "3":
                //         _service.GetDoctorById();
                //         break;
                //     case "4":
                //         _service.UpdateDoctor();
                //         break;
                //     case "5":
                //         _service.DeleteDoctor();
                //         break;
                //     case "6":
                //         Console.Write("Enter specialty (GeneralPractitioner, Cardiologist, Dermatologist, Neurologist, Pediatrician): ");
                //         if (Enum.TryParse(Console.ReadLine(), out Speciality speciality))
                //         {
                //             var doctors = _service.GetAllSpecialty(speciality);
                //             if (doctors.Count > 0)
                //             {
                //                 foreach (var doc in doctors)
                //                 {
                //                     Console.WriteLine(doc);
                //                 }
                //             }
                //             else
                //             {
                //                 Console.WriteLine($"No doctors found with specialty: {speciality}");
                //             }
                //         }
                //         else
                //         {
                //             Console.WriteLine("Invalid specialty.");
                //         }
                //         break;
                //     case "0":
                //         running = false;
                //         break;
                //     default:
                //         Console.WriteLine("Invalid option. Try again.");
                //         break;
                // }

            }

        }
    }
}