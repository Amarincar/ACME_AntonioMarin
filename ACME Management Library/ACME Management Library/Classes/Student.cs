using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACME_Management_Library.Classes;

namespace ACME_Management_Library.Classes
{
    internal class Student
    {
        public string Name { get; }
        public int Age { get; }

        public Student(string name, int age)
        {
            if (age < 18)
                throw new ArgumentException("Only adults can register.");
            Name = name;
            Age = age;
        }
    }
}
