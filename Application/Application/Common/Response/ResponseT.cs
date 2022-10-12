namespace Application.Common.Response;

public class Response<T> : Response
{
    public T Data { get; set; }

    internal Response(T data,string message, bool success, IEnumerable<string> Errors) : base(message, success, Errors)
    {
        Data = data;
    }
    
    public static Response<T> Success(T data, string message)
    {
        return new Response<T>(data, message, true, null);
    }
}