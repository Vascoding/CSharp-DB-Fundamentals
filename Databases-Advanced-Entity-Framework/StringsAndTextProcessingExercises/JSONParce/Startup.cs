using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONParce
{
    public class Student
    {
        public Student()
        {
            this.Grades = new List<int>();
        }
        public string Name { get; set; }

        public int Age { get; set; }

        public virtual List<int> Grades { get; set; }
    }
    public class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ', '[', ']', '{', '}', ',', ':', '"' }, StringSplitOptions.RemoveEmptyEntries);

            List<Student> students = new List<Student>();

            for (int i = 0; i < input.Length; i++)
            {
                Student student = new Student();
                if (input[i].Equals("name"))
                {
                    student.Name = input[i + 1];
                    student.Age = int.Parse(input[i + 3]);
                    for (int j = i + 5; j < input.Length; j++)
                    {
                        if (input[j].Equals("name"))
                        {
                            break;

                        }
                        student.Grades.Add(int.Parse(input[j]));
                    }
                    students.Add(student);
                }
            }

            foreach (var student in students)
            {
                Console.Write($"{student.Name} : {student.Age} -> ");
                if (student.Grades.Count == 0)
                {
                    Console.WriteLine("None");
                }
                else
                {
                    for (int i = 0; i < student.Grades.Count; i++)
                    {
                        if (i == student.Grades.Count - 1)
                        {
                            Console.WriteLine($"{student.Grades[i]}");
                        }
                        else
                        {
                            Console.Write($"{student.Grades[i]}, ");
                        }
                    }
                }
                
            }
        }
    }
}
