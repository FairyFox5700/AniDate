using System.Runtime.Serialization;
using AniDate.Common.Extensions;
using Newtonsoft.Json;

namespace AniDate.Common.Wrappers
{
    public class ApiResponse<T>: ApiResponse
    {
        public static readonly ApiResponse<T> Forbidden = new ApiResponse<T>(ErrorMessage.Forbidden.GetHttpStatusCode(),
            new ApiErrorResponse(message: ErrorMessage.Forbidden.GetDescription(),
                messageType: nameof(ErrorMessage.Forbidden)));
        public static readonly ApiResponse<T> BadRequest = new ApiResponse<T>(ErrorMessage.BadRequest.GetHttpStatusCode(),
            new ApiErrorResponse(message: ErrorMessage.BadRequest.GetDescription(),
                messageType: nameof(ErrorMessage.BadRequest)));
        public static readonly ApiResponse<T> NotFound = new ApiResponse<T>(ErrorMessage.NotFound.GetHttpStatusCode(),
            new ApiErrorResponse(message: ErrorMessage.NotFound.GetDescription(),
                messageType: nameof(ErrorMessage.NotFound)));
        public static readonly ApiResponse<T> Unauthorized = new ApiResponse<T>(ErrorMessage.Unauthorized.GetHttpStatusCode(),
            new ApiErrorResponse(message: ErrorMessage.Unauthorized.GetDescription(),
                messageType: nameof(ErrorMessage.Unauthorized)));
        public static readonly ApiResponse<T> ServerError = new ApiResponse<T>(ErrorMessage.ServerError.GetHttpStatusCode(),
            new ApiErrorResponse(message: ErrorMessage.ServerError.GetDescription(),
                messageType: nameof(ErrorMessage.ServerError)));
        [DataMember(EmitDefaultValue = false)]
        public T Data { get; set; }

        public ApiResponse()
        {
        }
        public ApiResponse(T result, int statusCode = 200):base(statusCode)
        {
            StatusCode = statusCode;
            Data = result;
            this.IsError = false;
        }
        public ApiResponse(int statusCode, ApiErrorResponse apiError) : base(statusCode, apiError) { }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this).ToString();
        }
       
    }
}