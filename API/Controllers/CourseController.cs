using API.Config.Swagger;
using API.Helpers;
using API.Models;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Services.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("v1")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        /// <summary>
        /// Get Courses
        /// </summary>        
        /// <remarks>Retrieves all courses.</remarks>
        [HttpGet]
        [Route("Courses")]
        [SwaggerResponse(200, null, typeof(GetCoursesOK))]
        [SwaggerOperation(Tags = new[] { "Courses" })]
        public async Task<IEnumerable<CourseModel>> GetAllCourses()
        {
            var courses = await _courseService.GetAllCourses();

            return courses.Select(x => new CourseModel()
            {
                Id = x.Id,
                Name = x.Name,
                CourseDates = x.CourseDates.Select(y => new CourseDateModel()
                {
                    Id = y.Id,
                    Date = y.AvailiabilityDate.ToString("yyyy-MM-dd")
                }).ToList()
            });
        }

        /// <summary>
        /// Get Course by Id
        /// </summary>        
        /// <remarks>Retrieves a specific course by ID.</remarks>
        /// <param name="id">Course ID</param>
        [HttpGet]
        [Route("Course")]
        [SwaggerResponse(200, null, typeof(GetCourseOK))]
        [SwaggerResponse(400, null, typeof(GetCourseBadRequest))]
        [SwaggerOperation(Tags = new[] { "Courses" })]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> GetCourseById([FromQuery, BindRequired] int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);

            if(course is null)
            {
                JsonResponse(HttpStatusCode.BadRequest, "Invalid Id. Course not found.");
            }

            var model = new CourseModel()
            {
                Id = course.Id,
                Name = course.Name,
                CourseDates = course.CourseDates.Select(y => new CourseDateModel()
                {
                    Id = y.Id,
                    Date = y.AvailiabilityDate.ToString("yyyy-MM-dd")
                }).ToList()
            };

            return JsonResponse(HttpStatusCode.OK, model);
        }

        /// <summary>
        /// Create Course Application
        /// </summary>        
        /// <remarks>Creates a new course application.</remarks>
        [HttpPost]
        [Route("CourseApplication")]
        [SwaggerResponse(200, null, typeof(CreateCourseApplicationOK))]
        [SwaggerResponse(400, null, typeof(CreateCourseApplicationBadRequest))]
        [SwaggerResponse(500, null, typeof(CreateCourseApplicationInternalServerError))]
        [SwaggerOperation(Tags = new[] { "Courses" })]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<ActionResult> CreateCourseApplication([FromBody, BindRequired]CourseApplicationModel model)
        {
            if (!ModelState.IsValid)
            {
                return JsonResponse(HttpStatusCode.BadRequest, ModelState.Values.SelectMany(x => x.Errors));
            }

            try
            {
                var selectedCourse = await _courseService.GetCourseByIdAsync(model.CourseId);
                var selectedDate = selectedCourse.CourseDates.Single(x => x.Id == model.DateId);

                var courseApplication = new CourseApplication()
                {
                    CompanyName = model.CompanyName,
                    CompanyEmail = model.CompanyEmail,
                    CompanyPhoneNumber = model.CompanyPhone,
                    Course = selectedCourse,
                    CourseDate = selectedDate,
                    CourseApplicationParticipants = model.Participants.Select(x => new CourseApplicationParticipant()
                    {
                        Name = x.Name,
                        Email = x.Email,
                        PhoneNumber = x.Phone
                    }).ToList()
                };

                await _courseService.CreateCourseApplicationAsync(courseApplication);

                return JsonResponse(HttpStatusCode.OK, "Application succesfully created");
            }
            catch (Exception ex)
            {
                return JsonResponse(HttpStatusCode.InternalServerError, new string[] { "Internal Server Error", ex.Message });
            }
        }

        #region helpers
        private ObjectResult JsonResponse(HttpStatusCode statusCode, object message)
        {
            var response = statusCode.CreateResult(message);

            return StatusCode((int)statusCode, response);
        }
        #endregion
    }
}
