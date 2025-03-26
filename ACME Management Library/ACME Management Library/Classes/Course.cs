using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ACME_Management_Library.Classes
{
    internal class Course
    {
        public string Name { get; }
        public decimal Fee { get; }
        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
        public List<Student> EnrolledStudents { get; } = new();

        public Course(string name, decimal fee, DateTime start, DateTime end)
        {
            Name = name;
            Fee = fee;
            StartDate = start;
            EndDate = end;
        }


        
        //public void Enroll(Student student, IPaymentGateway paymentGateway)
        //{
        //    if (paymentGateway.ProcessPayment(student, Fee))
        //        EnrolledStudents.Add(student);
        //    else
        //        throw new InvalidOperationException("Payment failed.");
        //}
    }
}
