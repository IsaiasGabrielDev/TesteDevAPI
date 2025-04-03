using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities;

public class ProductHistory
{
    [Key]
    public int Id { get; set; }
    public DateTime DateChange { get; set; } = DateTime.Now;
    public decimal LastPrice { get; set; }
    [ForeignKey("Product")]
    public int ProductId { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
}
