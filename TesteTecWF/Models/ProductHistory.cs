namespace TesteTecWF.Models;

public sealed record class ProductHistory(
    DateTime DateChange,
    decimal LastPrice,
    int ProductId,
    string UserName,
    string ProductName);