namespace Application.Common.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data, string message = default, int httpStatusCode = 500, string code = default) : base(false, code, message, httpStatusCode, data)
        {
        }

        public ErrorDataResult(string message = default, int httpStatusCode = 500, string code = default) : base(false, code, message, httpStatusCode, default)
        {
        }
    }
}