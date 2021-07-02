using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Application.Common.Results
{
    public class ValidationErrorResult : IResult
    {
        public ValidationErrorResult(List<ValidationError> errors)
        {
            Errors = errors;
        }

        public ValidationErrorResult(List<ValidationError> errors, string message)
        {
            Errors = errors;
            Message = message;
        }

        public List<ValidationError> Errors { get; set; }

        public bool Success { get; set; } = false;
        public string Code { get; set; } 
        public string Message { get; set; }
        public int HttpStatusCode { get; set; } = StatusCodes.Status500InternalServerError;
    }
}