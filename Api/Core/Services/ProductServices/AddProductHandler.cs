using Core.Abstraction;
using Core.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Core.Services.ProductServices;

internal sealed class AddProductHandler(
    IUnitOfWork unitOfWork,
    IProductRepository repository,
    IValidator<Product> validator) : IFunctionHandler<AddProductFunction>
{
    private IUnitOfWork _unitOfWork = unitOfWork;
    private IProductRepository _repository = repository;
    private IValidator<Product> _validator = validator;

    public AddProductFunction HandlerFunction => Handle;

    private async Task<(Product? product, string errorMessage)> Handle(
        AddProductDTO addProduct, CancellationToken cancellationToken)
    {
        try
        {
            Product product = new()
            {
                Name = addProduct.Name,
                Price = addProduct.Price,
                CategoryId = addProduct.CategoryId
            };

            ValidationResult validationResult = await _validator.ValidateAsync(product);
            if (!validationResult.IsValid)
                return (null, validationResult.ToString());

            Product? addedProduct = await _repository.AddProduct(product, cancellationToken);
            var rowsAffected = await _unitOfWork.CommitAsync(cancellationToken);
            return rowsAffected > 0
                    ? (addedProduct, string.Empty)
                    : (null!, "Falha ao adicionar o produto");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

public delegate Task<(Product? product, string errorMessage)> AddProductFunction(
    AddProductDTO addProduct, CancellationToken cancellationToken);

public sealed record AddProductDTO(
    string Name,
    decimal Price,
    int CategoryId);
