using System.Collections.Generic;
using FluentValidation.Results;
using Newtonsoft.Json;

namespace AniDate.Common.Wrappers
{
    public class ApiErrorResponse
    { 
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public  string Message { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string MessageType { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Errors { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public List<ValidationFailure> ValidationErrors { get; set; }
        public ApiErrorResponse()
        {
                
        }
        public ApiErrorResponse(string message, string messageType)
        {
            Message = message;
            MessageType = messageType;
        }
        public ApiErrorResponse(string message, string messageType, List<ValidationFailure> validationErrors):this(message,messageType)
        {
            ValidationErrors = new List<ValidationFailure>();
            ValidationErrors = validationErrors;
            this.MessageType = messageType;
        }
    }
}