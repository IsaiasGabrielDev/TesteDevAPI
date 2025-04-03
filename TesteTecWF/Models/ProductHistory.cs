namespace TesteTecWF.Models;

public sealed record class ProductHistory
{
    public DateTime DateChange { get; set; }
    public decimal LastPrice { get; set; }
    public int ProductId { get; set; }
    public string UserName { get; set; } = null!;
    public string ProductName { get; set; } = null!;
    public string CategoryName { get; set; } = null!;
}