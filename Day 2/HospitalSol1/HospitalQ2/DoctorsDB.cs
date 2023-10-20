using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalQ2
{
    internal class DoctorsDB
    {
        List<Doctor> doctors;

        public DoctorsDB()
        {
            doctors = new List<Doctor>();
        }
        int GetNextId()
        {
            if (doctors.Count == 0)
                return 1;
            int id = doctors[doctors.Count - 1].Id;
            return ++id;
        }

        public Doctor Add()
        {
            Doctor doctor = new Doctor();
            int id= GetNextId();
            doctor.Id = id;
            TakeRemainingDoctorsDetails(doctor);
            doctors.Add(doctor);
            return doctor;
        }

        public List<Doctor> GetDoctors()
        {
            return doctors;
        }
        void TakeRemainingDoctorsDetails(Doctor doctor)
        {
            Console.WriteLine("Enter the Doctor name : ");
            doctor.Name = Console.ReadLine();
            Console.WriteLine("Enter the Doctors Specialization : ");
            doctor.Specialization = Console.ReadLine();
            Console.WriteLine("Enter Doctors Expeience : ");
            doctor.Experience=Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Doctors phone : ");
            doctor.Phone=Convert.ToInt64(Console.ReadLine());

        }
        public int GetIdFromUser()
        {
            int id;
            Console.WriteLine("Enter Doctor's id : ");
            id = Convert.ToInt32(Console.ReadLine());
            return id;
        }
        public void ModifyDoctorPhone()
        {
            int id=GetIdFromUser();
            Console.WriteLine("Please enter the new phone : ");
            long phone = Convert.ToInt64(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Phone = phone;
            doctor.Id = id;
            var result = Update(id, doctor, "phone");
            if (result != null)
                Console.WriteLine("Update success");
        }

        public void ModifyDoctorExperience()
        {
            int id = GetIdFromUser();
            Console.WriteLine("Please enter the new experience : ");
            int exp = Convert.ToInt32(Console.ReadLine());
            Doctor doctor = new Doctor();
            doctor.Experience = exp;
            doctor.Id = id;
            var result = Update(id, doctor, "exp");
            if (result != null)
                Console.WriteLine("Update success");
        }

        public Doctor GetDoctorById(int id)
        {
            for (int i = 0; i < doctors.Count; i++)
            {
                if (doctors[i].Id == id)
                    return doctors[i];
            }
            return null;
        }


        public void ShowAllDoctors()
        {
            Console.WriteLine("***********************************");
            var doctos = GetDoctors();
            foreach (var item in doctors)
            {
                Console.WriteLine(item);
                Console.WriteLine("-------------------------------");
            }
            Console.WriteLine("***********************************");
        }
        
        Doctor Update(int id, Doctor doctor, string choice)
        {
            Doctor myDoctor = GetDoctorById(id);
            if (myDoctor != null)
            {

                if (choice == "phone")
                {
                    if (doctor.Phone> 0)
                    {
                        myDoctor.Phone = doctor.Phone;
                        return myDoctor;
                    }
                }
                else if (choice == "exp")
                {
                    if (doctor.Experience > 0)
                    {
                        myDoctor.Experience = doctor.Experience;
                        return myDoctor;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
            Console.WriteLine("Could not update");
            return null;
        }
        public void DeleteDoctor()
        {
            int id = GetIdFromUser();
            if (Delete(id) != null)
                Console.WriteLine("Doctor deleted");

        }
        public Doctor Delete(int id)
        {
            Doctor thisDoctor = GetDoctorById(id);
            if (thisDoctor != null)
            {
                doctors.Remove(thisDoctor);
                Console.WriteLine("Product deleted");
                return thisDoctor;
            }
            return null;

        }

    }
}
