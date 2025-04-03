using Core.Abstraction;
using Core.Entities;
using Core.Services.ProductHistoryService;
using FluentValidation;

namespace Core.Services.ProductServices;

internal class UpdateProductHandler(
    IUnitOfWork unitOfWork,
    IProductRepository repository,
    IUserRepository userRepository,
    AddProductHistoryFunction addProductHistoryFunction,
    IValidator<Product> validator)
    : IFunctionHandler<UpdateProductFunction>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IProductRepository _repository = repository;
    private readonly AddProductHistoryFunction _addProductHistoryFunction = addProductHistoryFunction;
    private readonly IUserRepository _userRepository = userRepository;

    public UpdateProductFunction HandlerFunction => Handle;

    private async Task<(Product? product, string? errorMessage)> Handle(
        Product productEdit, string userEmail, CancellationToken cancellationToken)
    {
        try
        {
            Product? product = await _repository.GetById(productEdit.Id, cancellationToken);
            if (product is null)
                return (null, "Produto não encontrado");

            if(productEdit.Price != product.Price)
                await ProductHistory(productEdit, userEmail, cancellationToken);

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

public delegate Task<(Product? product, string? errorMessage)> UpdateProductFunction(
    Product productEdit, string userEmail, CancellationToken cancellationToken);
