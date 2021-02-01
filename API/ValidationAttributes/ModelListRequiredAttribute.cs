using API.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace API.ValidationAttributes
{
    public class ModelListRequiredAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (!(value is List<CourseApplicationParticipantModel> list))
            {
                return false;
            }

            return list.Any();
        }
    }
}
