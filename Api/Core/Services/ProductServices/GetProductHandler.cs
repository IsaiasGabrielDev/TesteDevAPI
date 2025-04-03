using Core.Abstraction;
using Core.Entities;

namespace Core.Services.ProductServices;

internal sealed class GetProductHandler(
    IProductRepository repository) : IFunctionHandler<GetProductFunction>
{
    private readonly IProductRepository _repository = repository;
    public GetProductFunction HandlerFunction => Handle;

    private async Task<(object? products, Product? product)> Handle(
        GetProductQuery query, CancellationToken cancellationToken)
    {
        if(query.ProductId > 0)
            return (null, await _repository.GetById(query.ProductId, cancellationToken));

        return (await _repository.GetAll(cancellationToken, query.PageNumber, query.PageSize), null);
    }
}

public delegate Task<(object? products, Product? product)> GetProductFunction(
    GetProductQuery query, CancellationToken cancellationToken);

public sealed record GetProductQuery(
    int ProductId,
    int PageNumber,
    int PageSize);
