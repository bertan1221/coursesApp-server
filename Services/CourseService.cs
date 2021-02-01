using Data;
using Entities;
using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CourseService : ICourseService
    {
        private readonly IDbContext _dbContext;

        public CourseService(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Course>> GetAllCourses()
        {
            return _dbContext.Courses.Include(x => x.CourseDates).ToListAsync();
        }

        public Task<Course> GetCourseByIdAsync(int id)
        {
            return _dbContext.Courses.Include(x => x.CourseDates).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task CreateCourseApplicationAsync(CourseApplication courseApplication)
        {
            _dbContext.CourseApplications.Add(courseApplication);

            return _dbContext.SaveChangesAsync();
        }
    }
}
