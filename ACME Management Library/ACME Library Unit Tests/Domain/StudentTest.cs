using ACME_Management_Library.Classes;

namespace ACME_Library_Unit_Tests.Domain
{
    public class StudentTests
    {
        [Fact]
        public void Student_ShouldThrowException_WhenNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Student("", "García", new DateTime(2000, 12, 12)));
            Assert.Throws<ArgumentException>(() => new Student(" ", "García", new DateTime(2000, 12, 12)));
#nullable disable
            Assert.Throws<ArgumentException>(() => new Student(null, "García", new DateTime(2000, 12, 12)));
#nullable enable

        }

        [Fact]
        public void Student_ShouldThrowException_WhenLastNameIsEmpty()
        {
            Assert.Throws<ArgumentException>(() => new Student("Pedro", "", new DateTime(2000, 12, 12)));
            Assert.Throws<ArgumentException>(() => new Student("Pedro", " ", new DateTime(2000, 12, 12)));
            Assert.Throws<ArgumentException>(() => new Student("Pedro", null, new DateTime(2000, 12, 12)));
#nullable disable
            Assert.Throws<ArgumentException>(() => new Student("Pedro", null, new DateTime(2000, 12, 12)));
#nullable enable
        }

        [Fact]
        public void Student_ShouldThrowException_WhenAgeIsLessThan18()
        {
            Assert.Throws<ArgumentException>(() => new Student("John", "Doe", new DateTime(2015, 12, 12)));
        }

        [Fact]
        public void Student_ShouldCreateObject_WhenDataIsValid()
        {
            DateTime validBirthDate = new DateTime(2000, 12, 12);  // Edad mayor a 18
            var student = new Student("Juan", "García", validBirthDate);
            Assert.NotNull(student);
            Assert.Equal("Juan", student.Name);
            Assert.Equal("García", student.LastName);
            Assert.Equal(validBirthDate, student.DateOfBirth);
            Assert.NotEqual(Guid.Empty, student.Id); // Verifica que se le haya asignado un Id único
        }
    }
}
