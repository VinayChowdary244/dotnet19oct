using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HospitalQ2;
using ClinicDALLibrary;

namespace ClinicBLLibrary
{
    public interface IClinicServices
    {
        public Doctor AddDoctor(Doctor doctor);
        public Doctor UpdateDoctorPhone(int id, int phone);
        public Doctor UpdateDoctorExperience(int id, int experience);
        public List<Doctor> GetAllDoctors();
        public Doctor Delete(int id);
    }
}
