using System;

namespace Interface_IStudent
{
    public interface IStudent
    {
        string Name { get; set; }
        string FullName { get; set; }
        int[] Grades { get; set; }
        string GetName();
        string GetFullName();
        double GetAvgGrade();
    }

    public class Student : IStudent
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public int[] Grades { get; set; }

        public Student(string name, string fullName, int[] grades)
        {
            Name = name;
            FullName = fullName;
            Grades = grades;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetFullName()
        {
            return FullName;
        }

        public double GetAvgGrade()
        {
            double sum = 0;
            foreach (var grade in Grades)
            {
                sum += grade;
            }
            return sum / Grades.Length;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] grades = { 90, 85, 92, 88}; //90 баллов типа по Computer Science Internship)) а? А? поняли, да))))))
            string name = "Аймурат";
            string fullName = "Аймурат 'Арабская лезгинка' Идрисов";

            // Creating a Student object
            Student student = new Student(name, fullName, grades);

            // Accessing and displaying student information
            Console.WriteLine("Student Name: " + student.GetName());
            Console.WriteLine("Student Full Name: " + student.GetFullName());
            Console.WriteLine("Average Grade: " + student.GetAvgGrade());
        }
    }
}
