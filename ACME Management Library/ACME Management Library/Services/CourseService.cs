using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACME_Management_Library.Classes;
using ACME_Management_Library.Interfaces;
using ACME_Management_Library.Services;

namespace ACME_Management_Library.Services
{
    public class CourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository ?? throw new ArgumentNullException(nameof(courseRepository));
        }

        public IEnumerable<Course> GetCoursesWithStudents(DateTime startDate, DateTime endDate)
        {
            return _courseRepository
                .GetCoursesInDateRange(startDate, endDate)
                .Where(course => course.Students.Any());
        }
    }

}
