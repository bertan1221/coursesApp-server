using System;
using System.Collections.Generic;

namespace API.Models
{
    public class CourseModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<CourseDateModel> CourseDates { get; set; }
    }
}
