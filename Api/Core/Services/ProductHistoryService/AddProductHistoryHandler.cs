using Core.Abstraction;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Core.Services.ProductHistoryService;

internal sealed class AddProductHistoryHandler(
    IProductHistoryRepository repository,
    IUnitOfWork unitOfWork,
    ILogger<AddProductHistoryFunction> logger) : IFunctionHandler<AddProductHistoryFunction>
{
    private readonly IProductHistoryRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly ILogger<AddProductHistoryFunction> _logger = logger;

    public AddProductHistoryFunction HandlerFunction => Handle;

    private async Task<(ProductHistory? productHistory, string errorMessage)> Handle(
        ProductHistory productHistory, CancellationToken cancellationToken)
    {
        try
        {
            var addedProductHistory = await _repository.AddAsync(productHistory, cancellationToken);
            var rowsAffected = await _unitOfWork.CommitAsync(cancellationToken);
            return rowsAffected > 0
                ? (addedProductHistory, string.Empty)
                : (null, "Falha ao adicionar o histórico do produto");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao adicionar o histórico do produto");
            return (null, ex.Message);
        }
    }
}

public delegate Task<(ProductHistory? productHistory, string errorMessage)> AddProductHistoryFunction(
    ProductHistory productHistory, CancellationToken cancellationToken);