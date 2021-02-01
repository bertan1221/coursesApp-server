using Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public static class CoursesSeed
    {
        public static void SeedCourses(this ModelBuilder modelBuilder)
        {
            var courses = new Course[]
            {
                new Course()
                {
                    Id = 1,
                    Name = "Cutting trees, the ins and outs"
                },
                new Course()
                {
                    Id = 2,
                    Name = "CSS and you - a love story"
                },
                new Course()
                {
                    Id = 3,
                    Name = "Baking mud cakes using actual mud"
                },
                new Course()
                {
                    Id = 4,
                    Name = "Christmas eve - myth or reality?"
                },
                new Course()
                {
                    Id = 5,
                    Name = "LEGO colors through time"
                },
            };

            modelBuilder.Entity<Course>().HasData(courses);

            var courseDates = new CourseDate[]
            {
                new CourseDate()
                {
                    Id = 1,
                    AvailiabilityDate = new DateTime(2017, 1, 1),
                    CourseId = 1
                },
                new CourseDate()
                {
                    Id = 2,
                    AvailiabilityDate = new DateTime(2017, 10, 31),
                    CourseId = 1
                },
                new CourseDate()
                {
                    Id = 3,
                    AvailiabilityDate = new DateTime(2017, 5, 25),
                    CourseId = 2
                },
                new CourseDate()
                {
                    Id = 4,
                    AvailiabilityDate = new DateTime(2017, 5, 26),
                    CourseId = 2
                },
                new CourseDate()
                {
                    Id = 5,
                    AvailiabilityDate = new DateTime(2017, 5, 27),
                    CourseId = 2
                },
                new CourseDate()
                {
                    Id = 6,
                    AvailiabilityDate = new DateTime(2017, 1, 1),
                    CourseId = 3
                },
                new CourseDate()
                {
                    Id = 7,
                    AvailiabilityDate = new DateTime(2018, 12, 10),
                    CourseId = 3
                },
                new CourseDate()
                {
                    Id = 8,
                    AvailiabilityDate = new DateTime(2017, 4, 1),
                    CourseId = 3
                },
                new CourseDate()
                {
                    Id = 9,
                    AvailiabilityDate = new DateTime(2017, 12, 24),
                    CourseId = 4
                },
                new CourseDate()
                {
                    Id = 10,
                    AvailiabilityDate = new DateTime(2018, 12, 24),
                    CourseId = 4
                },
                new CourseDate()
                {
                    Id = 11,
                    AvailiabilityDate = new DateTime(2019, 12, 24),
                    CourseId = 4
                },
                new CourseDate()
                {
                    Id = 12,
                    AvailiabilityDate = new DateTime(2017, 6, 30),
                    CourseId = 5
                }
            };

            modelBuilder.Entity<CourseDate>().HasData(courseDates);
        }
    }
}
