using Core.Entities;

namespace Core.Abstraction;

internal interface IProduct
{
    Task<IQueryable<Product>> GetAll();
    Task<IQueryable<Product>> GetProductsByCategoryId(int categoryId);
    Task<Product> GetById(int productId);
    Task<Product> AddProduct(Product product);
    Task UpdateProduct(Product product);
    Task DeleteProduct(Product product);
}
