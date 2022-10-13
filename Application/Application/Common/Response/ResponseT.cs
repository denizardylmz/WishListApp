using Application.Interfaces;

namespace Application.Common.Response;

public class Response<T> : Response , IResponse<T>
{
    public T Data { get; set; }

    internal Response(T data,string message, bool success, IEnumerable<string> Errors) : base(message, success, Errors)
    {
        Data = data;
    }
    
    public static Response<T> Success(string message, T data)
    {
        return new Response<T>(data, message, true, Array.Empty<string>() );
    }
}