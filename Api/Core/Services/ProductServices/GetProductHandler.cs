using Core.Abstraction;
using Core.Entities;

namespace Core.Services.ProductServices;

internal sealed class GetProductHandler(
    IProductRepository repository) : IFunctionHandler<GetProductFunction>
{
    private readonly IProductRepository _repository = repository;
    public GetProductFunction HandlerFunction => Handle;

    private async Task<(IEnumerable<Product>? products, Product? product)> Handle(
        int productId, CancellationToken cancellationToken)
    {
        if(productId > 0)
            return (null, await _repository.GetById(productId, cancellationToken));

        return (await _repository.GetAll(cancellationToken), null);
    }
}

public delegate Task<(IEnumerable<Product>? products, Product? product)> GetProductFunction(
    int productId, CancellationToken cancellationToken);
