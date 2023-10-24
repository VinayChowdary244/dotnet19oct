using ClinicDALLibrary;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;

using System.Threading.Tasks;


namespace HospitalQ2
{
    public class DoctorDB : IDoctorDB
    {
        Dictionary<int,Doctor> doctors=new Dictionary<int,Doctor>();
        public Doctor Add(Doctor doctor)
        {
            int id = GetTheNextId();
            try
            {
                doctor.Id = id;
                doctors.Add(doctor.Id, doctor);
                    return doctor;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine("the product Id already exists");
                Console.WriteLine(e.Message);
            }
            return null;
            
        }

        public Doctor Delete(int id)
        {
            var doctor = doctors[id];
            doctors.Remove(id);
            return doctor;
        }

        public List<Doctor> GetAll()
        {
            var doctorList = doctors.Values.ToList();
            return doctorList;
        }

        public Doctor GetById(int id)
        {
           if(doctors.ContainsKey(id)) 
                return doctors[id];
            return null;
        }

        public Doctor Update(Doctor doctor)
        {
            doctors[doctor.Id] = doctor;
            return doctors[doctor.Id];
        }
        private int GetTheNextId()
        {
            if (doctors.Count == 0)
                return 1;
            int id = doctors.Keys.Max();
            return ++id;
        }
    }
}
