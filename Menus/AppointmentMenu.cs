using testperformance.Service;
using testperformance.Models;
using testperformance.Repositories;

namespace testperformance.Menus
{
    public static class AppointmentMenu
    {
        private static readonly AppointmentService _service = new();

        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Management Appoints Dates =====");
                Console.WriteLine("1. Agend a Date");
                Console.WriteLine("2. Cancel Date");
                Console.WriteLine("3. Mark as completed");
                Console.WriteLine("4. List dates by patient");
                Console.WriteLine("5. List dates by doctor");
                Console.WriteLine("0. Return to the Main Menu");
                Console.Write("Select a option: ");

                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        _service.ScheduleAppointment();
                        break;
                    case "2":
                        _service.CancelAppointment();
                        break;
                    case "3":
                        _service.MarkAsCompleted();
                        break;
                    case "4":
                        _service.ListByPatient();
                        break;
                    case "5":
                        _service.ListByDoctor();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option.");
                        break;
                }

                Console.WriteLine("Press a teckle to continue...");
                Console.ReadKey();
            }
        }
    }
}