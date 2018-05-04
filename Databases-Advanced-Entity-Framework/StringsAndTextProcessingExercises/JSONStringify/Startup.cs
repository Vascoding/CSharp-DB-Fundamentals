using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONStringify
{
    public class Student
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public List<int> Grades { get; set; }
    }
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new []{' ', ':', '-', '>', ','}, StringSplitOptions.RemoveEmptyEntries);

            List<Student> students = new List<Student>();

            while (true)
            {
                if (input[0].Equals("stringify"))
                {
                    break;
                }
                var name = input[0];
                var age = int.Parse(input[1]);
                List<int> grades = new List<int>();
                for (int i = 2; i < input.Length; i++)
                {
                    grades.Add(int.Parse(input[i]));
                }
                students.Add(new Student
                {
                    Name = name,
                    Age = age,
                    Grades = grades
                });

                input = Console.ReadLine().Split(new[] { ' ', ':', '-', '>', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            int count = -1;
            Console.Write("[");
            foreach (var student in students)
            {
                count++;
                Console.Write("{");
                Console.Write($"name:\"{student.Name}\",age:{student.Age},grades:[");
                if (student.Grades.Count != 0)
                {
                    for (int i = 0; i < student.Grades.Count - 1; i++)
                    {
                        Console.Write($"{student.Grades[i]}, ");
                    }
                    Console.Write($"{student.Grades[student.Grades.Count - 1]}]");
                }
                else
                {
                    Console.Write("]");
                }
                if (count == students.Count -1 )
                {
                    Console.Write("}");
                }
                else
                {
                    Console.Write("},");
                }
            }
            Console.WriteLine("]");
        }
    }
}
