using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicBLLibrary;
using ClinicDALLibrary;


namespace HospitalQ2
{
    public class ClinicHome
    {
        IClinicServices clinicServices;
        public ClinicHome()
        {
            clinicServices = new ClinicServices();
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
                        AddDoctor();
                        break;
                    case 2:
                        UpdateDoctorPhone();
                        break;
                    case 3:
                        UpdateDoctorExperience();
                        break;
                    case 4:
                        DeleteDoctor();
                        break;

                    case 5:
                        ShowAllDoctors();
                        break;
                }
            } while (choice != 0);
        }
        private void ShowAllDoctors()
        {
            Console.WriteLine("***********************************");
            var doctors = clinicServices.GetAllDoctors();
            foreach (var item in doctors)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }

        void AddDoctor()
        {
            try
            {
                Doctor doctor = TakeDoctorsDetails();
                var result = clinicServices.AddDoctor(doctor);
                if (result != null)
                {
                    Console.WriteLine("Doctor added");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);

            }
            catch (NotAddedException e)
            {
                Console.WriteLine(e.Message);
            }

        }

        Doctor TakeDoctorsDetails()
        {
            Doctor doctor=new Doctor();
            Console.WriteLine("Enter the Doctor name : ");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Enter the Doctors Specialization : ");
            doctor.Specialization = Console.ReadLine();
            Console.WriteLine("Enter Doctors Expeience : ");
            doctor.Experience = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Doctors phone : ");
            doctor.PhoneNum = Convert.ToInt64(Console.ReadLine());
            return doctor;
        }

        int GetDoctorIdFromUser()
        {
            int id;
            Console.WriteLine("Please enter the Doctor's id :");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }

        private void DeleteDoctor()
        {
            try
            {
                int id = GetDoctorIdFromUser();
                if (clinicServices.Delete(id) != null)
                    Console.WriteLine("Product deleted");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        private void UpdateDoctorPhone()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter the new phone");
            int phone = (int)Convert.ToInt64(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.PhoneNum = phone;
            doctor.Id = id;
            try
            {
                var result = clinicServices.UpdateDoctorPhone(id, phone);
                if (result != null)
                    Console.WriteLine("Update success");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }


        private void UpdateDoctorExperience()
        {
            var id = GetDoctorIdFromUser();
            Console.WriteLine("Please enter doctors new experience :");
            int exp = Convert.ToInt32(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Experience = exp;
            doctor.Id = id;
            try
            {
                var result = clinicServices.UpdateDoctorExperience(id, exp);
                if (result != null)
                    Console.WriteLine("Update success");
            }
            catch (NoSuchDoctorException e)
            {
                Console.WriteLine(e.Message);
            }
        }


        static int Main(string[] args)
        {
            Console.WriteLine("Welcome");
            ClinicHome home= new ClinicHome();
            home.StartAdminActivities();
            return 0;
        }

    }
}
