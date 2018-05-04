using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFAdvanced.Models
{
    class Student
    {
        public Student(string name)
        {
            this.Name = name;
            count++;
        }

        public static int count;
      
        public string Name { get; set; }
    }
}
