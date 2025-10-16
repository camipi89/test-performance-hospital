using testperformance.Service;
using testperformance.Models;
using testperformance.Repositories;

namespace testperformance.Menus
{
    public static class PatientMenu
    {
        
        
        private static readonly PatientService _service =
            new PatientService(new GenericRepository<Patient>()); // Inyección de dependencia

        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== PATIENT MENU =====");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. List All Patients");
                Console.WriteLine("3. Search Patient by ID");
                Console.WriteLine("4. Update Patient");
                Console.WriteLine("5. Delete Patient");
                Console.WriteLine("0. Return to Main Menu");
                Console.Write("\nSelect an option: ");

                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        _service.RegisterPatient();
                        break;
                    case "2":
                        _service.ListPatients();
                        break;
                    case "3":
                        _service.GetPatientById();
                        break;
                    case "4":
                        _service.UpdatePatient();
                        break;
                    case "5":
                        _service.DeletePatient();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}