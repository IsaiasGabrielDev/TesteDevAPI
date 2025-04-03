using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data;

public sealed partial class AppDbContext
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<ProductHistory> ProductHistories { get; set; }
}
