namespace DumplingManager.Application.Commons
{
    public class ApiResult<T>
    {
        public bool success { set; get; }
        public string message { set; get; }
        public T data { set; get; }
    }

    public class OkResult<T> : ApiResult<T>
    {
        public OkResult()
        {
            success = true;
            message = "";
        }

        public OkResult(T data)
        {
            this.data = data;
            success = true;
            message = "";
        }

        public OkResult(string message)
        {
            success = true;
            this.message = message;
        }
    }

    public class ErrorResult<T> : ApiResult<T>
    {
        public ErrorResult(string message)
        {
            success = false;
            this.message = message;
        }
    }
}
