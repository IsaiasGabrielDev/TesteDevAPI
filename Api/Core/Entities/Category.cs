using System.ComponentModel.DataAnnotations;

namespace Core.Entities;

public record class Category
{
    [Key]
    public int Id { get; set; }
    public string? Name { get; set; }
}
