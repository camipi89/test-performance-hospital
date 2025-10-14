using System;
using testperformance.Menus;


namespace testperformance.Menus
{
    public static class MainMenu
    {
        public static void Show()
        {
            while (true)
            {
                Console.WriteLine("1.  Patient Menu");
                Console.WriteLine("2.  Doctor Menu");
                Console.WriteLine("4.  Appointment Menu");
                Console.WriteLine("0.  Exit");
                Console.Write("\nSelect an option: ");



                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        PatientMenu.Show();
                        break;
                    case "2":
                        DoctorMenu.Show();
                        break;
                    case "3":
                        AppointmentMenu.Show();
                        break;
                    case "0":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("\nPress any key to return to the main menu...");
                 Console.ReadKey();

            }
        }
    }
}