using ACME_Management_Library.Infrastructure;

namespace ACME_Library_Unit_Tests.Domain
{

    public class CourseRepositoryTests
    {
        private readonly CourseRepository _repository;
        private readonly List<Course> _courses;

        public CourseRepositoryTests()
        {
            _repository = new CourseRepository();

            _courses = new List<Course>
        {
            new Course("C# Course", 50, new DateTime(2025, 5, 1), new DateTime(2025, 6, 1)),
            new Course("Java Advanced", 60, new DateTime(2026, 8, 1), new DateTime(2026, 10, 1)),
            new Course("Angular Advanced", 60, new DateTime(2025, 7, 14), new DateTime(2025, 11, 1))
        };

            foreach (var course in _courses)
            {
                _repository.Add(course);
            }
        }

        [Fact]
        public void CourseRepository_ShouldAddAndRetrieveCourse()
        {
            var newCourse = new Course("React Course", 80, DateTime.Now, DateTime.Now.AddDays(30));
            _repository.Add(newCourse);
            var retrievedCourse = _repository.GetById(newCourse.Id);

            Assert.NotNull(retrievedCourse);
            Assert.Equal(newCourse.Id, retrievedCourse.Id);
            Assert.Equal("React Course", retrievedCourse.Name);
        }

        [Theory]
        [InlineData("2025-04-15", "2025-07-15", 2)]
        [InlineData("2026-01-01", "2026-12-31", 1)]
        [InlineData("2024-01-01", "2024-12-31", 0)]
        public void CourseRepository_ShouldReturnCoursesInDateRange(string startDateStr, string endDateStr, int expectedCount)
        {
            var startDate = DateTime.Parse(startDateStr);
            var endDate = DateTime.Parse(endDateStr);

            var result = _repository.GetCoursesInDateRange(startDate, endDate);

            Assert.Equal(expectedCount, result.Count());
        }
    }
}