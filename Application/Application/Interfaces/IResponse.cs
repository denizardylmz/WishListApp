namespace Application.Interfaces;

public interface IResponse
{
    public string Message { get; set; }
    public bool Success { get; set; }
    public string[] Errors { get; set; }
}