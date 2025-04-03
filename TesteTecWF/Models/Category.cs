namespace TesteTecWF.Models;

public sealed record class Category(
    int Id,
    string Name,
    IEnumerable<Product> Products);
