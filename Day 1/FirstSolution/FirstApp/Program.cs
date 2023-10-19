using System.Collections.Concurrent;

namespace FirstApp
{
    internal class Program
    {
        static int GetARandomNumber()
        {
            int num1 = new Random().Next(1, 200);
            return num1;
        }
        static void CheckNumberStatus()
        {
            int num1;
            
            num1 = GetARandomNumber();
            if (num1 > 100)
                Console.WriteLine("Too big. The numebr is " + num1);
            else
                Console.WriteLine($"The number {num1} is Okay");
        }

        static void AddTwoNums()
        {
            int FirstNum= GetARandomNumber();
            int SecondNum= GetARandomNumber();
            int Total = FirstNum + SecondNum;
            Console.WriteLine("the sum is : " + Total);
        }
        static void Main(string[] args)
        {
            //string name;
            //Console.WriteLine("Enter your name");
            //name = Console.ReadLine();
            //Console.WriteLine("welcome " + name);
            //Console.WriteLine($"welcome {name} ");
            //int num1;
            //num1 = Convert.ToInt32(Console.ReadLine());
            CheckNumberStatus();
            AddTwoNums();
            
        }
    }
}