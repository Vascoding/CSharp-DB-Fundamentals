using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using EFAdvanced.Models;

namespace EFAdvanced
{
    class Startup
    {
        static void Main(string[] args)
        {
            // 1. Define a class Person
            //DefineClassPerson();

            //2. Create Person Constructors
            //var input = Console.ReadLine().Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            //CreatePersonConstructors(input);

            //3. Oldest Family Member
            //OldestFamilymember();

            //4. Students
            //Students();

            //5. Planck Constant
            //PlanckConstant();

            //6. Math Utilities
            //MathUtilities();

        }

        private static void MathUtilities()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();


            while (!input[0].Equals("End"))
            {
                double firstNum = double.Parse(input[1]);
                double secondNum = double.Parse(input[2]);
                if (input[0].Equals("Sum"))
                {
                    Console.WriteLine($"{MathUtil.Sum(firstNum, secondNum):F2}");
                }
                else if (input[0].Equals("Subtract"))
                {
                    Console.WriteLine($"{MathUtil.Subtract(firstNum, secondNum):F2}");
                }
                else if (input[0].Equals("Multiply"))
                {
                    Console.WriteLine($"{MathUtil.Multiply(firstNum, secondNum):F2}");
                }
                else if (input[0].Equals("Divide"))
                {
                    Console.WriteLine($"{MathUtil.Divide(firstNum, secondNum):F2}");
                }
                else if (input[0].Equals("Percentage"))
                {
                    Console.WriteLine($"{MathUtil.Percentage(firstNum, secondNum):F2}");
                }

                input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
        }

        private static void PlanckConstant()
        {
            Console.WriteLine(Calculation.ReducedPlanck());
        }

        private static void Students()
        {
            var input = Console.ReadLine();


            while (input != "End")
            {

                Student newStudent = new Student(input);

                input = Console.ReadLine();
            }

            Console.WriteLine(Student.count);
        }

        private static void OldestFamilymember()
        {
            var numOfMembers = int.Parse(Console.ReadLine());
            Family newFamily = new Family();
            for (int i = 0; i < numOfMembers; i++)
            {
                var inputMember = Console.ReadLine().Split().ToArray();
                string name = inputMember[0];
                int age = int.Parse(inputMember[1]);

                newFamily.AddMember(new Person(name, age));
            }
            var oldest = newFamily.GetOldestMember();
            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }

        private static void CreatePersonConstructors(string[] input)
        {
            
            if (input.Length == 0)
            {
                Person newPerson = new Person();
                Console.WriteLine($"{newPerson.Name} {newPerson.Age}");
            }
            else if (input.Length == 1)
            {
                string arg = input[0];
                int age = 0;

                if (int.TryParse(arg, out age))
                {
                    Person newPerson = new Person(age);
                    Console.WriteLine($"{newPerson.Name} {newPerson.Age}");
                }
                else
                {
                    Person newPerson = new Person(arg);
                    Console.WriteLine($"{newPerson.Name} {newPerson.Age}");

                }
            }
            else if (input.Length == 2)
            {
                string name = input[0];
                int age = int.Parse(input[1]);
                Person newPerson = new Person(name, age);
                Console.WriteLine($"{newPerson.Name} {newPerson.Age}");

            }
        }

        private static void DefineClassPerson()
        {
            Person firstPerson = new Person();
            Person secondPerson = new Person();
            Person thirdPerson = new Person();
            firstPerson.Name = "Pesho";
            firstPerson.Age = 20;
            secondPerson.Name = "Gosho";
            secondPerson.Age = 18;
            thirdPerson.Name = "Stamat";
            thirdPerson.Age = 43;

            Console.WriteLine(firstPerson.Name);
            Console.WriteLine(firstPerson.Age);
            Console.WriteLine(secondPerson.Name);
            Console.WriteLine(secondPerson.Age);
            Console.WriteLine(thirdPerson.Name);
            Console.WriteLine(thirdPerson.Age);
        }
    }
}
