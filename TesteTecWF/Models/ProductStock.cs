namespace TesteTecWF.Models;

public sealed record class ProductStock
{
    public int TotalProducts { get; set; }
    public decimal TotalStockValue { get; set; }
    public decimal AverageProductPrices { get; set; }
}
