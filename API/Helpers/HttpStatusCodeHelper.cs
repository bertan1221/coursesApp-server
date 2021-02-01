using API.Models;
using System.Net;

namespace API.Helpers
{
    public static class HttpStatusCodeHelper
    {

        public static ApiResult CreateResult(this HttpStatusCode statusCode, object result)
        {
            var apiResult = new ApiResult()
            {
                Status = (int)statusCode,
                Result = result
            };

            return apiResult;
        }

    }
}
