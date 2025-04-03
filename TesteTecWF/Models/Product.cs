namespace TesteTecWF.Models;

public sealed record class Product(
int? Id,
string Name,
decimal Price,
int CategoryId);

public sealed record class ResponseProduct(
    int TotalRecords,
    IEnumerable<Product> Products);