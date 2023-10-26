using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClinicDALLibrary;

using HospitalQ2;
using System.Diagnostics;
using System.Numerics;


namespace ClinicBLLibrary
{
    public class ClinicServices : IClinicServices
    {
        IDoctorDB doctordb;
        public ClinicServices()
        {
            doctordb = new DoctorDB();
        }
        public Doctor AddDoctor(Doctor doctor)
        {
            var result = doctordb.Add(doctor);
            if (result != null)
                return result;
            throw new NotAddedException();
        }

        public Doctor Delete(int id)

        {
            var result = GetDoctor(id);
            if (result != null)
            {
                doctordb.Delete(id);
                return result;
            }

            throw new NoSuchDoctorException();
        }
        public Doctor GetDoctor(int id)
        {
            var result = doctordb.GetById(id);
            return result == null ? throw new NoSuchDoctorException() : result;

        }
        public List<Doctor> GetAllDoctors()
        {
            var doctors = doctordb.GetAll();
            if (doctors.Count != 0) return doctors;
            throw new NoDoctorsAvailable();
        }



        public Doctor UpdateDoctorExperience(int id, int experience)
        {

            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                doctor.Experience = experience;
                var result = doctordb.Update(doctor);
                return result;
            }
            throw new NoSuchDoctorException();
        }

        public Doctor UpdateDoctorPhone(int id, int phone)
        {

            var doctor = GetDoctor(id);
            if (doctor != null)
            {
                doctor.Experience = phone;
                var result = doctordb.Update(doctor);
                return result;

                throw new NotImplementedException();
            }
            return null;



        }
    }
}
