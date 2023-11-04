namespace liskov
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
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Consultant();
            employee.Work();
            ((Consultant)employee).DoMoreWork();//cast to call the additional method
        }
    }
}