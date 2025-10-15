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
                        Console.Write("Enter appointment ID to cancel: ");
                        if (int.TryParse(Console.ReadLine(), out int cancelId))
                            _service.CancelAppointment(cancelId);
                        else
                            Console.WriteLine("Invalid ID.");
                        break;

                    case "3":
                        Console.Write("Enter appointment ID to mark as completed: ");
                        if (int.TryParse(Console.ReadLine(), out int completeId))
                            _service.MarkAppointmentAsCompleted(completeId);
                        else
                            Console.WriteLine("Invalid ID.");
                        break;

                    case "4":
                        Console.Write("Enter patient ID: ");
                        if (int.TryParse(Console.ReadLine(), out int patientId))
                            _service.ListAppointmentsByPatient(patientId);
                        else
                            Console.WriteLine("Invalid ID.");
                        break;

                    case "5":
                        Console.Write("Enter doctor ID: ");
                        if (int.TryParse(Console.ReadLine(), out int doctorId))
                            _service.ListAppointmentsByDoctor(doctorId);
                        else
                            Console.WriteLine("Invalid ID.");
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