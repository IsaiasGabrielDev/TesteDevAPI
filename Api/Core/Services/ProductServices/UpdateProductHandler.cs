using Core.Abstraction;
using Core.Entities;
using FluentValidation;

namespace Core.Services.ProductServices;

internal class UpdateProductHandler(
    IUnitOfWork unitOfWork,
    IProductRepository repository,
    IValidator<Product> validator)
    : IFunctionHandler<UpdateProductFunction>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IProductRepository _repository = repository;

    public UpdateProductFunction HandlerFunction => Handle;

    private async Task<(Product? product, string? errorMessage)> Handle(
        Product productEdit, CancellationToken cancellationToken)
    {
        try
        {
            Product? product = await _repository.GetById(productEdit.Id, cancellationToken);
            if (product is null)
                return (null, "Produto não encontrado");

            product.Name = productEdit.Name;
            product.Price = productEdit.Price;
            product.CategoryId = productEdit.CategoryId;

            var validationResult = await validator.ValidateAsync(product);
            if (!validationResult.IsValid)
                return (null, validationResult.ToString());

            await _repository.UpdateProduct(product);
            var rowsAffected = await _unitOfWork.CommitAsync(cancellationToken);
            return rowsAffected > 0
                ? (product, string.Empty)
                : (null, "Falha ao atualizar produto");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

public delegate Task<(Product? product, string? errorMessage)> UpdateProductFunction(
    Product productEdit, CancellationToken cancellationToken);
