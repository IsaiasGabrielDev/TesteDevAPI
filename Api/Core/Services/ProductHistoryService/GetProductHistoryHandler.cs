using Core.Abstraction;
using Core.Entities;
using Microsoft.Extensions.Logging;

namespace Core.Services.ProductHistoryService;

internal class GetProductHistoryHandler(
    IProductHistoryRepository repository,
    ILogger<GetProductHistoryFunction> logger) : IFunctionHandler<GetProductHistoryFunction>
{
    private readonly IProductHistoryRepository _repository = repository;
    private readonly ILogger<GetProductHistoryFunction> _logger = logger;

    public GetProductHistoryFunction HandlerFunction => Handle;

    private async Task<IEnumerable<ProductHistory>> Handle(
        GetProductHistoryRequest request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetProductHistoryHandler called with request: {Request}", request);
        if (request.ProductId > 0)
        {
            return await _repository.GetByProductIdAsync(request.ProductId, cancellationToken);
        }
        else if (request.UserId > 0)
        {
            return await _repository.GetByUserIdAsync(request.UserId, cancellationToken);
        }

        _logger.LogWarning("Invalid request: {Request}", request);
        throw new Exception($"Invalid request: {request}");
    }
}

public delegate Task<IEnumerable<ProductHistory>> GetProductHistoryFunction(
    GetProductHistoryRequest request,
    CancellationToken cancellationToken);

public sealed record class GetProductHistoryRequest(
    int ProductId,
    int UserId);