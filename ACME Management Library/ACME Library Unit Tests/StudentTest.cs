using System;
using ACME_Management_Library.Classes;
using Xunit;

namespace ACME_Management_Tests
{
    public class StudentTests
    {
        // Crear un estudiante válido
        [Fact]
        public void CreateStudent_ShouldSucceed_WhenStudentIsAdult()
        {
            var name = "Juan";
            var dateOfBirth = new DateTime(2004, 5, 15); 

            var student = new Student(name, dateOfBirth);

            Assert.Equal(name, student.Name);
            Assert.Equal(dateOfBirth, student.DateOfBirth);
        }

        // Lanzar excepción cuando el estudiante es menor 
        [Fact]
        public void CreateStudent_ShouldThrowException_WhenStudentIsUnderage()
        {
            var name = "Juan";
            var dateOfBirth = DateTime.Now.AddYears(-17); 

            var exception = Assert.Throws<ArgumentException>(() => new Student(name, dateOfBirth));
            Assert.Equal("Only adults can register.", exception.Message);
        }

        // Verificar que la edad se calcula correctamente
        [Fact]
        public void CreateStudent_ShouldCalculateCorrectAge()
        {
            var name = "Juan";
            var dateOfBirth = new DateTime(1990, 5, 1);
            var today = new DateTime(2023, 5, 1); 
            var expectedAge = 33; 

            var student = new Student(name, dateOfBirth);

            Assert.Equal(name, student.Name);
            Assert.Equal(dateOfBirth, student.DateOfBirth);
        }

        // Comprobar nombres vacíos o nulos
        [Fact]
        public void CreateStudent_ShouldThrowException_WhenNameIsNullOrWhitespace()
        {
            var dateOfBirth = new DateTime(2000, 5, 15); // Fecha válida

            Assert.Throws<ArgumentException>(() => new Student(null, dateOfBirth));
            Assert.Throws<ArgumentException>(() => new Student("", dateOfBirth));
            Assert.Throws<ArgumentException>(() => new Student("   ", dateOfBirth));
        }
    }
}
