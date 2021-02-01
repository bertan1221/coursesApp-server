using API.Models;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace API.Config.Swagger
{
    public class ResponseExample
    {
    }

    public class GetCourseOK : ApiResult, IExamplesProvider<GetCourseOK>
    {
        public GetCourseOK GetExamples()
        {
            return new GetCourseOK
            {
                Status = (int)HttpStatusCode.OK,
                Result = new CourseModel()
                {
                    Id = 1,
                    Name = "Example Course",
                    CourseDates = new List<CourseDateModel>(){ new CourseDateModel()
                        {
                            Id = 1,
                            Date = "2020-01-01"
                        }
                    }
                }
            };
        }
    }

    public class GetCoursesOK : IExamplesProvider<GetCoursesOK>
    {
        public List<CourseModel> Courses { get; set; }

        public GetCoursesOK GetExamples()
        {
            return new GetCoursesOK
            {
                Courses = new List<CourseModel>(){ new CourseModel()
                {
                    Id = 1,
                    Name = "Example Course",
                    CourseDates = new List<CourseDateModel>(){ new CourseDateModel()
                        {
                            Id = 1,
                            Date = "2020-01-01"
                        }
                    }
                }
                }
            };
        }
    }

    public class GetCourseBadRequest : ApiResult, IExamplesProvider<GetCourseBadRequest>
    {
        public GetCourseBadRequest GetExamples()
        {
            return new GetCourseBadRequest
            {
                Status = (int)HttpStatusCode.BadRequest,
                Result = "Invalid Id. Course not found."
            };
        }
    }

    public class CreateCourseApplicationOK : ApiResult, IExamplesProvider<CreateCourseApplicationOK>
    {
        public CreateCourseApplicationOK GetExamples()
        {
            return new CreateCourseApplicationOK
            {
                Status = (int)HttpStatusCode.OK,
                Result = "Application succesfully created"
            };
        }
    }

    public class CreateCourseApplicationBadRequest : ApiResult, IExamplesProvider<CreateCourseApplicationBadRequest>
    {
        public CreateCourseApplicationBadRequest GetExamples()
        {
            return new CreateCourseApplicationBadRequest
            {
                Status = (int)HttpStatusCode.BadRequest,
                Result = new object[] { "CompanyName is required." }
            };
        }
    }

    public class CreateCourseApplicationInternalServerError : ApiResult, IExamplesProvider<CreateCourseApplicationInternalServerError>
    {
        public CreateCourseApplicationInternalServerError GetExamples()
        {
            return new CreateCourseApplicationInternalServerError
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Result = new object[] { "Internal Server Error", "Exception message." }
            };
        }
    }
}
