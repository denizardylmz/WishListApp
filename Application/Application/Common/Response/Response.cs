namespace Application.Common.Response;

public class Response
{
    public string Message { get; set; }
    public bool Success { get; set; }
    public string[] Errors { get; set; }

    internal Response(string message, bool success, IEnumerable<string> Errors)
    {
        message = Message;
        success = Success;
        Errors = Errors.ToArray();
    }
    
    public static Response SuccessResponse(string message)
    {
        return new Response(message, true, null);
    }
    
    public static Response ErrorResponse(string message, IEnumerable<string> errors)
    {
        return new Response(message, false, errors);
    }
}
