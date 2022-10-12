namespace Application.Common.Models;

public  class Result
{
    internal Result(bool success, IEnumerable<string> errors)
    {
        Success = success;
        Errors = errors.ToArray();
    }

    public bool Success { get; set; }
    
    public string[] Errors { get; set; }
    
    public static Result SuccessResult()
    {
        return new Result(true, Array.Empty<string>());
    }
    
    public static Result FailureResult(IEnumerable<string> errors)
    {
        return new Result(false, errors);
    }
}