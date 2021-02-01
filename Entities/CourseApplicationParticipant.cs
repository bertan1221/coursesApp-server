using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class CourseApplicationParticipant
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [ForeignKey("CourseApplication")]
        public  int CourseApplicationId { get; set; }

        public virtual CourseApplication CourseApplication { get; set; }
    }
}
