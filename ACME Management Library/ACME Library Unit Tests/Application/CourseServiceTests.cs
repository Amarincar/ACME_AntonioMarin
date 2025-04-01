using ACME_Library_Unit_Tests.Mocks;
using ACME_Management_Library.Classes;
using ACME_Management_Library.Interfaces;
using ACME_Management_Library.Services;
using Moq;

namespace ACME_Library_Unit_Tests.Application
{
    public class CourseServiceTests
    {
        private readonly Mock<ICourseRepository> _mockRepo;
        private readonly CourseService _service;
        private readonly List<Course> _courses;

        public CourseServiceTests()
        {
            _mockRepo = new Mock<ICourseRepository>();
            _service = new CourseService(_mockRepo.Object);

            _courses = new List<Course>
        {
            new Course("C# Basics", 50, new DateTime(2025, 5, 1), new DateTime(2025, 6, 1)),
            new Course("Java Advanced", 60, new DateTime(2025, 7, 1), new DateTime(2025, 9, 1)),
            new Course("Angular Fundamentals", 60, new DateTime(2025, 6, 1), new DateTime(2025, 8, 1))
        };
        }

        [Fact]
        public void Constructor_ShouldThrowException_WhenRepositoryIsNull()
        {
#nullable disable
            Assert.Throws<ArgumentNullException>(() => new CourseService(null));
#nullable enable
        }

        [Fact]
        public void GetCoursesWithStudents_ShouldReturnOnlyCoursesWithStudents()
        {
            var student = new Student("Juan", "García", new DateTime(2000, 1, 1));
            _courses[1].EnrollStudent(student, new FakePaymentService(true)); // Solo en curso Java Advanced

            _mockRepo.Setup(repo => repo.GetCoursesInDateRange(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                     .Returns(_courses);

            var result = _service.GetCoursesWithStudents(new DateTime(2025, 4, 15), new DateTime(2025, 8, 15));

            Assert.Single(result);
            Assert.Contains(_courses[1], result);
            Assert.DoesNotContain(_courses[0], result);
            Assert.DoesNotContain(_courses[2], result);
        }

        [Fact]
        public void GetCoursesWithStudents_ShouldReturnEmptyList_WhenNoCoursesHaveStudents()
        {
            _mockRepo.Setup(repo => repo.GetCoursesInDateRange(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                     .Returns(_courses);

            var result = _service.GetCoursesWithStudents(new DateTime(2025, 4, 15), new DateTime(2025, 8, 15));
            Assert.Empty(result);
        }
    }
}