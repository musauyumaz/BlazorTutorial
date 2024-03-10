namespace Application.Commons.Results
{
    public class DataResult<T> : IDataResult<T> where T : class
    {
        public DataResult(string message, bool isSucceeded, T data) : this(isSucceeded, data)
        {
            Message = message;
        }

        public DataResult(bool isSucceeded, T data)
        {
            IsSucceeded = isSucceeded;
            Data = data;
        }

        public string Message { get; }

        public bool IsSucceeded { get; }

        public T Data { get; }
    }
}



