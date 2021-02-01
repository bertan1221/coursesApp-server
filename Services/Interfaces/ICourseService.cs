using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourses();

        Task<Course> GetCourseByIdAsync(int id);

        Task CreateCourseApplicationAsync(CourseApplication courseApplication);
    }
}
