using System;
using testperformance.Repositories;
using testperformance.Models;
using testperformance.Service;

namespace testperformance.Menus
{
    public static class DoctorMenu
    {
        private static readonly DoctorService _service = new();

        public static void Show()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== Management Doctors =====");
                Console.WriteLine("1. Register Doctor");
                Console.WriteLine("2. List Doctors");
                Console.WriteLine("3. Search Doctors by ID");
                Console.WriteLine("4. Update Doctor");
                Console.WriteLine("5. Delete Doctor");
                Console.WriteLine("0. Return to the Main Menu");
                Console.Write("\nSelect a option: ");

                string? option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        _service.RegisterDoctor();
                        break;
                    case "2":
                        _service.ListDoctors();
                        break;
                    case "3":
                        _service.GetDoctorById();
                        break;
                    case "4":
                        _service.UpdateDoctor();
                        break;
                    case "5":
                        _service.DeleteDoctor();
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid Option.");
                        break;
                }

                Console.WriteLine("Press a teckle to continue ...");
                Console.ReadKey();
            }
        }
    }

    internal class DoctorService
    {
        internal void DeleteDoctor()
        {
            throw new NotImplementedException();
        }

        internal void GetDoctorById()
        {
            throw new NotImplementedException();
        }

        internal void ListDoctors()
        {
            throw new NotImplementedException();
        }

        internal void RegisterDoctor()
        {
            throw new NotImplementedException();
        }

        internal void UpdateDoctor()
        {
            throw new NotImplementedException();
        }
    }
}