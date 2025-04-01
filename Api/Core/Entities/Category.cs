using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public record class Category
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public IEnumerable<Product> Products { get; set; } = new List<Product>();

    public Category(string name)
    {
        Name = name;
    }
}
