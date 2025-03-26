using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME_Library_Unit_Tests
{
    internal class StudentTest
public class CourseTests
    {
        private class FakeGateway : IPaymentGateway
        {
            public bool ProcessPayment(Student s, decimal a) => true;
        }

        [Fact]
        public void Enroll_Student_When_Payment_Succeeds()
        {
            var student = new Student("Carlos", 22);
            var course = new Course("Math", 100, DateTime.Today, DateTime.Today.AddMonths(1));
            course.Enroll(student, new FakeGateway());
            Assert.Contains(student, course.EnrolledStudents);
        }
    }
}
