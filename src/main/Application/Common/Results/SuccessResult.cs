namespace Application.Common.Results
{
    public class SuccessResult : Results.Result
    {
        public SuccessResult(string message = default, int httpStatusCode = 200, string code = default) : base(true,
            message, code, httpStatusCode)
        {
        }
    }
}