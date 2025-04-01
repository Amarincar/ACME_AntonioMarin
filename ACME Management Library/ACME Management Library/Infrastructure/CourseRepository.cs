using ACME_Management_Library.Interfaces;

namespace ACME_Management_Library.Infrastructure
{
    public class CourseRepository : ICourseRepository
    {
        private readonly List<Course> _courses = new();

        public void Add(Course course)
        {
            if (course == null)
                throw new ArgumentNullException(nameof(course));

            _courses.Add(course);
        }

        public Course GetById(Guid id)
        {
#nullable disable
            return _courses.FirstOrDefault(c => c.Id == id);
#nullable enable
        }

        public IEnumerable<Course> GetCoursesInDateRange(DateTime startDate, DateTime endDate)
        {
            return _courses.Where(c => c.StartDate <= endDate && c.EndDate >= startDate).ToList();
        }
    }
}
