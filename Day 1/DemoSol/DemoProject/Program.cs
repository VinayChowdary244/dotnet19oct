namespace DemoProject
{
    internal class Program
    {
        static int Inp()  //method to take input.
        {
            int num = Convert.ToInt32(Console.ReadLine());
            return num;
        }
        static void AddNums()  //Taking input of two numbers and giving the sum.
        {
            int num1 = Inp();
            int num2 = Inp();
            int sum = num1+ num2;
            Console.WriteLine("Sum of the two numbers is : "+sum);
        }
        static void Biggest()  //Giving the biggest out of the two numbers.
        {
            int num1 = Inp();
            int num2 = Inp();
            int biggest;
            if (num1 > num2) biggest= num1;
            else biggest= num2;
            Console.WriteLine("the biggest number is : " + biggest);
        }
        static void CheckEven()
        {
            int num = Inp();
            if (num % 2 == 0) Console.WriteLine("the number is even");
            else Console.WriteLine("the number is not even");
        }
        static void CheckPrime()    //takes in a number and checks if its a prime or not
        {
            int num = Inp();
            Boolean flag= false;
            for(int i = 2; i < num / 2; ++i)
            {
                if (num % i == 0)
                {
                   flag=true;
                    break;
                }
                
            }
            if(flag=true) { Console.WriteLine("the number is not a prime"); }
            else Console.WriteLine("the number is a prime no");
        }
        static void FindSquare()   // takes in a number and gives the square of thet number.
        {
            int num= Inp();
            int sqr = num * num;
            Console.WriteLine("Square of the number = "+sqr);
        }
        static void AvgOfTen()     // takes 10 numbers and gives out their average.
        {
            int sum = 0;
            
            for(int i = 0; i < 10; i++)
            {
                int a=Inp();
                sum += a;
            }
            int avg=sum/10;
            Console.WriteLine("the average of the given ten numbers is : "+avg);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            AddNums();
            Biggest();
            CheckEven();
            CheckPrime();
            FindSquare();
            AvgOfTen();
        }
    }
}