
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SolidApp
{
    class Employee
    {
        public virtual void Work()
        {
            Console.WriteLine("Work in Employee");
        }
    }
    class Consultant : Employee
    {
        public override void Work()
        {
            base.Work();
            Console.WriteLine("Work as consultant");
        }
        public void DoMoreWork()
        {
            Console.WriteLine("Do more work in Consulant");
        }
    }
    
}
