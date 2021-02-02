using API.ValidationAttributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CourseApplicationModel
    {
        [Required]
        [JsonProperty("courseId")]
        public int CourseId { get; set; }

        [Required]
        [JsonProperty("dateId")]
        public int DateId { get; set; }

        [Required]
        [JsonProperty("companyName")]
        public string CompanyName { get; set; }

        [Required]
        [JsonProperty("companyPhone")]
        public string CompanyPhone { get; set; }

        [Required]
        [EmailAddress]
        [JsonProperty("companyEmail")]
        public string CompanyEmail { get; set; }

        [ModelListRequired]
        [JsonProperty("participants")]
        public List<CourseApplicationParticipantModel> Participants { get; set; }
    }

    public class CourseApplicationParticipantModel
    {
        [Required]
        [EmailAddress]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("phone")]
        public string Phone { get; set; }
        }
}
