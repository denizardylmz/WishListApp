using Application.Interfaces;

namespace Application.Common.Response;

public class Response : IResponse
{
    public string Message { get; set; }
    public bool Success { get; set; }
    public string[] Errors { get; set; }

    internal Response(string message, bool success, IEnumerable<string> errors)
    {
        Message = message;
        Success = success;
        Errors = errors.ToArray();
    }
    
    public static Response SuccessResponse(string message)
    {
        return new Response(message, true, Array.Empty<string>());
    }
    public static Response NotFoundResponse(string message)
    {
        return new Response(message, false, Array.Empty<string>());
    }
    public static Response ErrorResponse(string message, IEnumerable<string> errors)
    {
        return new Response(message, false, errors);
    }
}
