using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HospitalQ2
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public string Specialization { get; set; } 
        public int Experience { get; set; }
        public int PhoneNum {  get; set; }

        public Doctor()
        {
            Name = null;
            Experience = 0;
            PhoneNum = 0;
        }
        public Doctor(int id,string name, string specialization, int experience, int phone)
        {
            Id= id;
            Name= name; 
            Specialization= specialization;
            Experience= experience;
            PhoneNum = phone;

        }
        public override string ToString()
        {
            
            return $"Doctor Id : {Id}\nDoctor Name : {Name}\nDoctor Specialization : {Specialization}\nDoctor Phone : {PhoneNum}\nDoctor Experience : {Experience}";
        }
    }
}
