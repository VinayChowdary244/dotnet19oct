using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusModelLibrary
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public double Phone { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }

        public Customer()
        {
            Id = 0;
            Phone = 0.00;
        }

        public Customer(int id, string name, double phone, string email, string password)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Email = email;
            Password = password;
        }

        public override string ToString()
        {
            return $"Customer Id : {Id}\n Customer Name : {Name}\n Customer PhoneNumber : {Phone}\n Customer Email :{Email}\n Customer Password : {Password}\n";
        }
    }
}
