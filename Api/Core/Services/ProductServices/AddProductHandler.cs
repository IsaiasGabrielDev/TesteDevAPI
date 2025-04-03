using Core.Abstraction;
using Core.Entities;
using Core.Services.ProductHistoryService;
using FluentValidation;
using FluentValidation.Results;

namespace Core.Services.ProductServices;

internal sealed class AddProductHandler(
    IUnitOfWork unitOfWork,
    IProductRepository repository,
    IUserRepository userRepository,
    AddProductHistoryFunction addProductHistoryFunction,
    IValidator<Product> validator) : IFunctionHandler<AddProductFunction>
{
    private IUnitOfWork _unitOfWork = unitOfWork;
    private IProductRepository _repository = repository;
    private IUserRepository _userRepository = userRepository;
    private AddProductHistoryFunction _addProductHistoryFunction = addProductHistoryFunction;
    private IValidator<Product> _validator = validator;

    public AddProductFunction HandlerFunction => Handle;

    private async Task<(Product? product, string errorMessage)> Handle(
        AddProductDTO addProduct, string userEmail, CancellationToken cancellationToken)
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

            await ProductHistory(addedProduct, userEmail, cancellationToken);
            return rowsAffected > 0
                    ? (addedProduct, string.Empty)
                    : (null!, "Falha ao adicionar o produto");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    private async Task ProductHistory(
        Product product, string userEmail, CancellationToken cancellationToken)
    {
        int userId = await GetUserId(userEmail, cancellationToken);
        var productHistory = new ProductHistory
        {
            ProductId = product.Id,
            UserId = userId,
            LastPrice = product.Price,
            DateChange = DateTime.UtcNow
        };

        await _addProductHistoryFunction(productHistory, cancellationToken);
    }

    private async Task<int> GetUserId(string userEmail, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserByEmail(userEmail, cancellationToken);
        if (user is null)
            throw new Exception($"Usuário não encontrado: {userEmail}");
        return user.Id;
    }
}

public delegate Task<(Product? product, string errorMessage)> AddProductFunction(
    AddProductDTO addProduct, string userEmail, CancellationToken cancellationToken);

public sealed record AddProductDTO(
    string Name,
    decimal Price,
    int CategoryId);
