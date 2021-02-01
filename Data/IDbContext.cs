using Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data
{
    public interface IDbContext
    {
        DbSet<Course> Courses { get; set; }

        DbSet<CourseDate> CourseDates { get; set; }

        DbSet<CourseApplication> CourseApplications { get; set; }

        DbSet<CourseApplicationParticipant> CourseApplicationParticipants { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
