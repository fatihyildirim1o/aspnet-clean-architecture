namespace Application.Common.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message = default, int httpStatusCode = 200, string code = default) :
            base(true, code, message, httpStatusCode, data)
        {
        }
    }
}