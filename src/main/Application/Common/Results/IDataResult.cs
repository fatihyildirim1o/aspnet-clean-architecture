namespace Application.Common.Results
{
    public interface IDataResult<T> : IResult
    {
        public T Data { get; set; }
    }
}