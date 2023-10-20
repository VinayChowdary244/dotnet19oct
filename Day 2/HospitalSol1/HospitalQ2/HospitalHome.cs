using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQ2
{
    internal class HospitalHome
    {
        DoctorsDB doctorsdb;
        public HospitalHome()
        {
            doctorsdb = new DoctorsDB();
        }
        void DisplayAdminMenu()
        {
            Console.WriteLine("1. Add Doctor");
            Console.WriteLine("2. Modify Doctor Phone");
            Console.WriteLine("3. Modify Doctor Experience");
            Console.WriteLine("4. Delete Doctor");
            Console.WriteLine("5. Show All Doctors");
            Console.WriteLine("0. Exit");
        }
        void StartAdminActivities()
        {
            int choice;
            do
            {
                DisplayAdminMenu();
                choice=Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 0:
                        Console.WriteLine("Bye bye");
                        break;
                    case 1:
                        doctorsdb.Add();
                        break;
                    case 2:
                        doctorsdb.ModifyDoctorPhone();
                        break;
                    case 3:
                        doctorsdb.ModifyDoctorExperience();
                        break;
                    case 4:
                        doctorsdb.DeleteDoctor();
                        break;

                    case 5:
                        doctorsdb.ShowAllDoctors();
                        break;
                }
            } while (choice != 0);
        }




        static void Main(string[] args)
        {
            Console.WriteLine("Welcome");
            HospitalHome home= new HospitalHome();
            home.StartAdminActivities();
        }

    }
}
