using Core.Abstraction;

namespace Core.Services.ProductServices;

internal class DeleteProductHandler(
    IUnitOfWork unitOfWork,
    IProductRepository repository) : IFunctionHandler<DeleteProductFunction>
{
    private readonly IProductRepository _repository = repository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public DeleteProductFunction HandlerFunction => Handle;

    private async Task<(bool isDelete, string? errorMessage)> Handle(
        int productId, CancellationToken cancellationToken)
    {
        try
        {
            var product = await _repository.GetById(productId, cancellationToken);
            if (product is null)
                return (false, "Produto não encontrado");

            await _repository.DeleteProduct(product);
            var rowsAffected = await _unitOfWork.CommitAsync(cancellationToken);

            return rowsAffected > 0
                ? (true, string.Empty)
                : (false, "Falha ao deletar produto");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}

public delegate Task<(bool isDelete, string? errorMessage)> DeleteProductFunction(
    int productId, CancellationToken cancellationToken);