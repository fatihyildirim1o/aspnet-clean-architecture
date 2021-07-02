namespace Application.Common.Results
{
    public interface IResult
    {
        public bool Success { get; set; }
        public string Code { get; set; }
        public string Message { get; set; }
        public int HttpStatusCode { get; set; }
    }
}