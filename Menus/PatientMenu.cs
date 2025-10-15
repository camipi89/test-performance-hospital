using System;
using testperformance.Repositories;
using testperformance.Models;
using testperformance.Service;

namespace testperformance.Menus
{
    public static class PatientMenu
    {
        public static void Show()
        {
            var patientService = new PatientService(); 

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Patient Menu ===");
                Console.WriteLine("1. Register Patient");
                Console.WriteLine("2. List Patients");
                Console.WriteLine("3. Search Patient by ID");
                Console.WriteLine("4. Update Patient");
                Console.WriteLine("5. Delete Patient");
                Console.WriteLine("0. Return to Main Menu");
                Console.Write("\nSelect an option: ");

                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        patientService.RegisterPatient();
                        break;
                    case "2":
                        patientService.ListPatients();
                        break;
                    case "3":
                        patientService.GetPatientById();
                        break;
                    case "4":
                        patientService.UpdatePatient();
                        break;
                    case "5":
                        patientService.DeletePatient();
                        break;
                    case "0":
                        return; 
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}