using ACME_Management_Library.Interfaces;
using ACME_Management_Library.Utils;

namespace ACME_Management_Library.Classes
{
    public class Student
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }

        public Student(string name, string lastName, DateTime dateOfBirth)
        {
            Validators.ValidateName(name, "student's name");
            Validators.ValidateName(lastName, "student's lastname");
            Validators.ValidateAdultStudent(dateOfBirth);

            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }
    }
}
