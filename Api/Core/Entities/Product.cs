using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public record class Product
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    [ForeignKey(nameof(Category))]
    public int CategoryId { get; set; }
}
