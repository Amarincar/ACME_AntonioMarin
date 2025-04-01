using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACME_Management_Library.Interfaces
{
    public interface ICourseRepository
    {
        void Add(Course course);
        Course? GetById(Guid id); // Puede ser null si el curso no existe
        IEnumerable<Course> GetCoursesInDateRange(DateTime startDate, DateTime endDate);
    }
}
