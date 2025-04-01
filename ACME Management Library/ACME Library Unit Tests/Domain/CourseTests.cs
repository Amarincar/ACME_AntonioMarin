using ACME_Library_Unit_Tests.Mocks;
using ACME_Management_Library.Classes;

namespace ACME_Library_Unit_Tests.Domain
{
    public class CourseTests
    {

        [Fact]
        public void Course_ShouldThrowException_WhenNameIsEmptyOrNull()
        {
            Assert.Throws<ArgumentException>(() => new Course("", 100, DateTime.Now, DateTime.Now.AddDays(30)));
            Assert.Throws<ArgumentException>(() => new Course("  ", 100, DateTime.Now, DateTime.Now.AddDays(30)));
#nullable disable
            Assert.Throws<ArgumentException>(() => new Course(null, 100, DateTime.Now, DateTime.Now.AddDays(30)));
#nullable enable
        }

        [Fact]
        public void Course_ShouldThrowException_WhenRegistrationFeeIsNegative()
        {
            Assert.Throws<ArgumentException>(() => new Course("Angular Course", -10, DateTime.Now, DateTime.Now.AddDays(30)));
        }

        [Fact]
        public void Course_ShouldThrowException_WhenStartDateIsAfterEndDate()
        {
            Assert.Throws<ArgumentException>(() => new Course("Angular Course", 100, DateTime.Now.AddDays(10), DateTime.Now));
        }

        [Fact]
        public void Course_ShouldThrowException_WhenStartDateIsBeforeToday()
        {
            Assert.Throws<ArgumentException>(() => new Course("Angular Course", 100, DateTime.Now.AddDays(-10), DateTime.Now.AddDays(10)));
        }

        [Fact]
        public void Course_ShouldThrowException_WhenStudentIsAlreadyEnrolled()
        {
            var course = new Course("Angular Course", 100, DateTime.Now, DateTime.Now.AddDays(30));
            var student = new Student("Pedro", "Pérez", new DateTime(2000, 1, 1));
            var paymentService = new FakePaymentService(true);

            course.EnrollStudent(student, paymentService);
            var exception = Assert.Throws<InvalidOperationException>(() => course.EnrollStudent(student, paymentService));
            Assert.Equal("Student is already enrolled in this course.", exception.Message);
        }

        [Fact]
        public void Course_ShouldThrowException_WhenPaymentFails()
        {
            var course = new Course("Angular Course", 100, DateTime.Now, DateTime.Now.AddDays(30));
            var student = new Student("Ana", "López", new DateTime(2000, 1, 1));
            var paymentService = new FakePaymentService(false); // Simulamos fallo en pago

            var exception = Assert.Throws<InvalidOperationException>(() => course.EnrollStudent(student, paymentService));
            Assert.Equal("Payment failed. Enrollment denied.", exception.Message);
        }

        [Fact]
        public void Course_ShouldEnrollStudent_WhenPaymentIsSuccessful()
        {
            var course = new Course("Angular Course", 100, DateTime.Now, DateTime.Now.AddDays(30));
            var student = new Student("Toni", "Díaz", new DateTime(2000, 1, 1));
            var paymentService = new FakePaymentService(true);

            course.EnrollStudent(student, paymentService);
            Assert.Contains(student, course.Students);
        }

        [Fact]
        public void Course_ShouldEnrollStudent_WhenCourseIsFree()
        {
            var course = new Course("Free Course", 0, DateTime.Now, DateTime.Now.AddDays(30));
            var student = new Student("Carlos", "López", new DateTime(1995, 5, 10));
            var paymentService = new FakePaymentService(false);

            course.EnrollStudent(student, paymentService);
            Assert.Contains(student, course.Students);
        }
    }
}

