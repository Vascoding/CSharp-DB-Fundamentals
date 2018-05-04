using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstStudentSystem
{
    class Startup
    {
        static void Main(string[] args)
        {
            // Working with Database
            StudentContext context = new StudentContext();

            // 1. List all students and their homework submissions
            //ListStudents(context);

            // 2. List all courses with their corresponding resources
            //ListCoursesResources(context);

            // 3. List all courses with more than 5 resources
            //ListCoursesWithMoreThen5Resourses(context);

            // 4. List all courses which were active on a given date 
            //ListActiveCourses(context);

            // 5. For each student, get the number of courses he/she has enrolled in
            //ListAllStudents(context);
        }

        private static void ListAllStudents(StudentContext context)
        {
            var student = context.Students.OrderByDescending(s => s.Courses.Sum(c => c.Price))
                            .ThenByDescending(s => s.Courses.Count)
                            .ThenBy(s => s.Name).ToList();

            foreach (var s in student)
            {
                Console.WriteLine($"{s.Name} {s.Courses.Count} {s.Courses.Sum(c => c.Price)} {s.Courses.Average(c => c.Price)}");
            }
        }

        private static void ListActiveCourses(StudentContext context)
        {
            DateTime date = new DateTime(2015, 6, 9);
            var courses =
                context.Courses.Where(c => c.StartDate < date && c.EndDate > date)
                .OrderByDescending(c => c.Students.Count)
                .ToList();

            foreach (var c in courses)
            {
                var datediff = (c.EndDate - c.StartDate).TotalDays;
                Console.WriteLine($@"Course Name: {c.Name}, Start Date: {c.StartDate}, End Date: {c.EndDate}, Duration: {datediff} Days, Students Enrolled: {c.Students.Count}.");
            }
        }

        private static void ListCoursesWithMoreThen5Resourses(StudentContext context)
        {
            var resources =
                            context.Resources.Where(r => r.Course.Resources.Count > 5).OrderByDescending(r => r.Course.Resources.Count)
                                .ThenByDescending(r => r.Course.StartDate)
                                .ToList();
            foreach (var r in resources)
            {
                Console.WriteLine($"{r.Course.Name} {r.Course.Resources.Count}");
            }
        }

        private static void ListCoursesResources(StudentContext context)
        {
            var resources = context.Resources.OrderBy(r => r.Course.StartDate).ThenByDescending(r => r.Course.EndDate).ToList();
            foreach (var r in resources)
            {
                Console.WriteLine($"{r.Course.Name} {r.Course.Description} {r.Name} {r.ResourceType} {r.Url}");
            }
        }

        private static void ListStudents(StudentContext context)
        {
            var home = context.Homeworks.ToList();
            foreach (var h in home)
            {
                Console.WriteLine($"{h.Student.Name} {h.Content} {h.ContentType}");
            }
        }
    }
}
