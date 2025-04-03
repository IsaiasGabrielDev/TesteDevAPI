﻿using Core.Entities;

namespace Core.Abstraction;

public interface IProductRepository
{
    Task<object> GetAll(CancellationToken cancellationToken, int pageNumber = 1, int pageSize = 20);
    Task<Product> GetById(int productId, CancellationToken cancellationToken);
    Task<object> GetProductsReportStock(CancellationToken cancellationToken);
    Task<Product> AddProduct(Product product, CancellationToken cancellationToken);
    Task UpdateProduct(Product product);
    Task DeleteProduct(Product product);
}
