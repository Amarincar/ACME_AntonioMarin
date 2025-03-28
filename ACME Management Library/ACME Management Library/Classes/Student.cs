using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACME_Management_Library.Classes;

namespace ACME_Management_Library.Classes
{
    public class Student
    {
        public string Name { get; }
        public DateTime DateOfBirth { get; }

        public Student(string name, DateTime dateOfBirth)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The student's name cannot be null, empty, or consist only of white spaces.");

            int age = CalculateAge(dateOfBirth);

            if (age < 18)
                throw new ArgumentException("Only adults can register.");

            Name = name;
            DateOfBirth = dateOfBirth;
        }
        private int CalculateAge(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = DateTime.Today.Year - dateOfBirth.Year;

            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
