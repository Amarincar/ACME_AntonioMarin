using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACME_Management_Library.Interfaces;
using ACME_Management_Library.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ACME_Management_Library.Classes
{
    public class Course
    {
        public string Name { get; private set; }
        public decimal RegistrationFee { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        private List<Student> EnrolledStudents { get; } = new List<Student>();

        public Course(string name, DateTime startDate, DateTime endDate, decimal registrationFee = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("The course name cannot be empty.");
            if (registrationFee < 0)
                throw new ArgumentException("The registration fee cannot be negative.");
            if (startDate >= endDate) // TODO : Mover a DateUtils
                if (!DateUtils.IsValidDateRange(startDate, endDate))
                    throw new ArgumentException("Start date must be earlier than end date.");

            Name = name;
            RegistrationFee = registrationFee;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void EnrollStudent(Student student, IPaymentGateway paymentGateway)
        {
            if (StartDate <= DateTime.Now) // TODO : Mover a DateUtils
                throw new InvalidOperationException("The course has already started.");
            if (EnrolledStudents.Contains(student))
                throw new InvalidOperationException($"The student {student.Name} is already enrolled in this course.");

            if (RegistrationFee > 0)
            {
                bool paymentSuccessful = paymentGateway.ProcessPayment(student, RegistrationFee);
                if (!paymentSuccessful)
                    throw new InvalidOperationException($"Payment of {RegistrationFee:C} failed for student {student.Name}.");
            }

            EnrolledStudents.Add(student);
        }

        public IReadOnlyList<Student> GetEnrolledStudents()
        {
            return EnrolledStudents.AsReadOnly();
        }
    }
}