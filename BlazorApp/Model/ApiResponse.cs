namespace BlazorApp.Model;



public class Error
{
    public int Code { get; set; }
    public string? Message { get; set; }
}

public class ApiResponse
{
    public Guid Id { get; set; }
    public Error? Error { get; set; }
}