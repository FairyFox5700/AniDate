using System;
using System.ComponentModel;

namespace AniDate.Common
{
    public enum ErrorMessage
    {
        [Description("Non authorized attempt to get resource")]
        [HttpStatusCode(401)]
        Unauthorized,
        [Description("Forbidden")]
        [HttpStatusCode(403)]
        Forbidden,
        [Description("Your request can not be proceeded")]
        [HttpStatusCode(400)]
        BadRequest,
        [Description("The object you are trying to find was not found")]
        [HttpStatusCode(404)]
        NotFound,
        [Description("Your request cannot be processed. Please contact a support.")]
        [HttpStatusCode(500)]
        ServerError,
       

    }
    public class HttpStatusCodeAttribute : Attribute
    {
        public int StatusCode { get; private set; }

        public HttpStatusCodeAttribute(int statusCode)
        {
            StatusCode = statusCode;
        }
    }
}