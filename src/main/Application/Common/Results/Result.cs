namespace Application.Common.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message, string code, int httpStatusCode)
        {
            Success = success;
            Code = code;
            HttpStatusCode = httpStatusCode;
            Message = message;
        }

        public bool Success { get; set; }
        public string Code { get; set; }
        public int HttpStatusCode { get; set; }
        public string Message { get; set; }
    }
}