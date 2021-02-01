using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<CourseDate> CourseDates { get; set; }

        public virtual ICollection<CourseApplication> CourseApplications { get; set; }
    }
}
