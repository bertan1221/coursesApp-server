using Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Data
{
    public class CoursesDataContext : DbContext, IDbContext
    {
        public CoursesDataContext(DbContextOptions<CoursesDataContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }

        public DbSet<CourseDate> CourseDates { get; set; }

        public DbSet<CourseApplication> CourseApplications { get; set; }

        public DbSet<CourseApplicationParticipant> CourseApplicationParticipants { get; set; }

        public Task<int> SaveChangesAsync() => base.SaveChangesAsync();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.SeedCourses();
        }
    }
}
