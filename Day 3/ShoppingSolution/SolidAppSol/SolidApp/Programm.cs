﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidApp
{
    internal class Program
    {
        //delegate void MyDelegate();
        //delegate void CalDel(int num1,int num2);
        //void CalledFunction()
        //{
        //    Console.WriteLine("Function Called");
        //}
        void Add(int n1, int n2)
        {
            Console.WriteLine($"The sum is {n1 + n2}");
        }
        void InvokeFunction()
        {
            //MyDelegate del = new MyDelegate(CalledFunction);
            //MyDelegate del = delegate ()
            //{
            //    Console.WriteLine("Function Called");
            //};
            //MyDelegate del = ()=>Console.WriteLine("Function Called");
            //del();//invocation
            Action action = () => Console.WriteLine("Function Called");
            action();
            //CalDel calDel = (n1, n2)=>Console.WriteLine($"The sum is {n1 + n2}");
            //calDel(10, 20);
            Action<int, int> calDel = (n1, n2) => Console.WriteLine($"The sum is {n1 + n2}");
            calDel(10, 20);
        }
        void UnderstandingDelegatesMore()
        {
            List<Student> students = new List<Student>()
            {
                new Student() {Id=101,Name="Ramu",Age=34},
                new Student(102,"Bimu",44),
                new Student() { Id = 10, Name = "Somu", Age = 22 }
            };
            //var myStudent = students.Where(s => s.Name == "Ramu");
            //foreach (var student in myStudent)
            //{
            //    Console.WriteLine(student.Id+" "+student.Name+" "+student.Age);
            //}
            var myStudent = students.OrderByDescending(s => s.Name);
            foreach (var student in myStudent)
            {
                Console.WriteLine(student.Id + " " + student.Name + " " + student.Age);
            }
            Console.WriteLine("*****************************");
            var singleStudent = students.FirstOrDefault(s => s.Id == 101 && s.Name == "Ramu");
            if (singleStudent != null)
                Console.WriteLine(singleStudent.Id + " " + singleStudent.Name + " " + singleStudent.Age);
            else
                Console.WriteLine("No such student");
        }
        static void Main(string[] args)
        {
            Program program = new Program();
            program.UnderstandingDelegatesMore();
        }
    }
}
