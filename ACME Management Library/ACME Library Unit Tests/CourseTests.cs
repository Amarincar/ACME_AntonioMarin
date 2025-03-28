using System;
using System.Collections.Generic;
using ACME_Management_Library.Classes;
using ACME_Management_Library.Interfaces;
using Moq;
using Xunit;

namespace ACME_Management_Tests
{
    public class CourseTests
    {
        // Crear un curso válido
        [Fact]
        public void CreateCourse_ShouldSucceed_WhenDataIsValid()
        {
            var name = "Advanced Programming";
            var startDate = DateTime.Now.AddDays(10);
            var endDate = DateTime.Now.AddMonths(1);
            var registrationFee = 150;

            var course = new Course(name, startDate, endDate, registrationFee);

            Assert.Equal(name, course.Name);
            Assert.Equal(startDate, course.StartDate);
            Assert.Equal(endDate, course.EndDate);
            Assert.Equal(registrationFee, course.RegistrationFee);
        }

        // Lanza excepción si las fechas son inválidas
        [Fact]
        public void CreateCourse_ShouldThrowException_WhenStartDateIsAfterEndDate()
        {
            var name = "Invalid Course";
            var startDate = DateTime.Now.AddMonths(2);
            var endDate = DateTime.Now.AddMonths(1);
            var registrationFee = 50;

            var exception = Assert.Throws<ArgumentException>(() => new Course(name, startDate, endDate, registrationFee));
            Assert.Equal("Start date must be earlier than end date.", exception.Message);
        }

        // Inscribir un estudiante correctamente
        [Fact]
        public void EnrollStudent_ShouldSucceed_WhenPaymentIsSuccessful()
        {
            var course = new Course("Advanced Programming", DateTime.Now.AddDays(10), DateTime.Now.AddMonths(1), 150);
            var student = new Student("Alice", new DateTime(2000, 5, 15));
            var paymentGatewayMock = new Mock<IPaymentGateway>();
            paymentGatewayMock.Setup(pg => pg.ProcessPayment(student, 150)).Returns(true);

            course.EnrollStudent(student, paymentGatewayMock.Object);

            Assert.Contains(student, course.GetEnrolledStudents());
        }

        // Lanzar excepción si el curso ha empezado
        [Fact]
        public void EnrollStudent_ShouldThrowException_WhenCourseAlreadyStarted()
        {
            var course = new Course("Expired Course", DateTime.Now.AddDays(-1), DateTime.Now.AddMonths(1), 100);
            var student = new Student("Alice", new DateTime(2000, 5, 15));
            var paymentGatewayMock = new Mock<IPaymentGateway>();

            var exception = Assert.Throws<InvalidOperationException>(() => course.EnrollStudent(student, paymentGatewayMock.Object));
            Assert.Equal("The course has already started.", exception.Message);
        }

        // Lanzar excepción si falla el pago
        [Fact]
        public void EnrollStudent_ShouldThrowException_WhenPaymentFails()
        {
            var course = new Course("Advanced Programming", DateTime.Now.AddDays(10), DateTime.Now.AddMonths(1), 150);
            var student = new Student("Alice", new DateTime(2000, 5, 15));
            var paymentGatewayMock = new Mock<IPaymentGateway>();
            paymentGatewayMock.Setup(pg => pg.ProcessPayment(student, 150)).Returns(false);

            var exception = Assert.Throws<InvalidOperationException>(() => course.EnrollStudent(student, paymentGatewayMock.Object));
            Assert.Equal($"Payment of {150:C} failed for student {student.Name}.", exception.Message);
        }

        // Lanzar excepción si el estudiante ya está inscrito
        [Fact]
        public void EnrollStudent_ShouldThrowException_WhenStudentAlreadyEnrolled()
        {
            var course = new Course("Advanced Programming", DateTime.Now.AddDays(10), DateTime.Now.AddMonths(1), 150);
            var student = new Student("Alice", new DateTime(2000, 5, 15));
            var paymentGatewayMock = new Mock<IPaymentGateway>();
            paymentGatewayMock.Setup(pg => pg.ProcessPayment(student, 150)).Returns(true);

            course.EnrollStudent(student, paymentGatewayMock.Object);

            var exception = Assert.Throws<InvalidOperationException>(() => course.EnrollStudent(student, paymentGatewayMock.Object));
            Assert.Equal($"The student {student.Name} is already enrolled in this course.", exception.Message);
        }
    }
}
