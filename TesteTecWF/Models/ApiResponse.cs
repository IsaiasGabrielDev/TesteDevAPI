namespace TesteTecWF.Models;

public sealed record class ApiResponse<T>
{
    public bool Status { get; init; }
    public string? Message { get; init; }
    public T? Data { get; init; }
}
