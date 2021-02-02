using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class CourseApplication
    {
        [Key]
        public int Id { get; set; }
                
        public string CompanyName { get; set; }

        public string CompanyEmail { get; set; }

        public string CompanyPhoneNumber { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        [ForeignKey("CourseDate")]
        public int CourseDateId { get; set; }

        public virtual CourseDate CourseDate { get; set; }

        public virtual ICollection<CourseApplicationParticipant> CourseApplicationParticipants { get; set; }
    }
}
