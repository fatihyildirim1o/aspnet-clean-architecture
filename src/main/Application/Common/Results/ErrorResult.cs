namespace Application.Common.Results
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message = default, int httpStatusCode = 500, string code = default) : base(false,
            message, code, httpStatusCode)
        {
        }
    }
}