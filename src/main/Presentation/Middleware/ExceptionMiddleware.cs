using Application.Common.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Presentation.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch
            {
                await HandleExceptionAsync(httpContext);
            }
        }
        private static async Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = new ErrorResult
            {
                HttpStatusCode = context.Response.StatusCode,
                Message = "Internal Server Error."
            };

            await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
        }
    }
}
