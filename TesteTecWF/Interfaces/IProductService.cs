using TesteTecWF.Models;

namespace TesteTecWF.Interfaces;

public interface IProductService
{
    Task<ApiResponse<ResponseProduct>> GetProductsAsync(int pageNumber, int pageSize);
    Task<ApiResponse<Product>> GetProductAsync(int id);
    Task<ApiResponse<Product>> AddProductAsync(Product product);
    Task<ApiResponse<Product>> UpdateProductAsync(Product product);
    Task<bool> DeleteProductAsync(int id);
}
