using Core.Abstraction;
using Microsoft.Extensions.Logging;

namespace Core.Services.ProductServices;

internal class GetProductsReportStockHandler(
    IProductRepository productRepository,
    ILogger<GetProductsReportStockHandler> logger) : IFunctionHandler<GetProductsReportStockFunction>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly ILogger<GetProductsReportStockHandler> _logger = logger;

    public GetProductsReportStockFunction HandlerFunction => Handle;

    public async Task<object> Handle(CancellationToken cancellationToken)
    {
        try
        {
            _logger.LogInformation("GetProductsReportStockHandler started");
            var result = await _productRepository.GetProductsReportStock(cancellationToken);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error in GetProductsReportStockHandler");
            throw;
        }
    }
}

public delegate Task<object> GetProductsReportStockFunction(CancellationToken cancellationToken);