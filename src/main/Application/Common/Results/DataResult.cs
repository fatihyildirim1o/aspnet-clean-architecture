namespace Application.Common.Results
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(bool success, string code, string message, int httpStatusCode, T data)
        {
            Success = success;
            Code = code;
            Message = message;
            HttpStatusCode = httpStatusCode;
            Data = data;
        }

        public bool Success { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public int HttpStatusCode { get; set; }
        public T Data { get; set; }
    }
}