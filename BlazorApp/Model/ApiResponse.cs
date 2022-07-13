namespace BlazorApp.Model;



public class Error
{
    public int code { get; set; }
    public string message { get; set; }
}

public class ApiResponse
{
    public Guid id { get; set; }
    public Error error { get; set; }
}