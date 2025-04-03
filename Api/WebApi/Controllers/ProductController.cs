using Core.Entities;
using Core.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(AuthenticationSchemes = "Bearer")]
public class ProductController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetProduct(
        [FromServices] GetProductFunction function,
        [FromQuery] int productId,
        [FromQuery] int pageNumber,
        [FromQuery] int pageSize,
        CancellationToken cancellationToken)
    {
        GetProductQuery query = new(productId, pageNumber, pageSize);
        var (products, product) = await function(query, cancellationToken);
        return product is not null
            ? Ok(product)
            : Ok(products);
    }

    [HttpGet("stock")]
    public async Task<IActionResult> GetProductReport(
        [FromServices] GetProductsReportStockFunction function,
        CancellationToken cancellationToken)
    {
        var obj = await function(cancellationToken);
        return obj is not null
            ? Ok(obj)
            : BadRequest("Erro ao obter os dados do relatório");
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(
        [FromServices] AddProductFunction function,
        [FromBody] AddProductDTO addProductDTO,
        CancellationToken cancellation)
    {
        string userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
        if (string.IsNullOrEmpty(userEmail))
            return Unauthorized("Usuário não autorizado");

        var (product, errorMessage) = await function(addProductDTO, userEmail, cancellation);
        return string.IsNullOrEmpty(errorMessage)
            ? Ok(product)
            : BadRequest(errorMessage);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateProduct(
        [FromServices] UpdateProductFunction function,
        [FromBody] Product product,
        CancellationToken cancellationToken)
    {
        string userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value!;
        if (string.IsNullOrEmpty(userEmail))
            return Unauthorized("Usuário não autorizado");

        var (updatedProduct, errorMessage) = await function(product, userEmail, cancellationToken);
        return string.IsNullOrEmpty(errorMessage)
            ? Ok(updatedProduct)
            : BadRequest(errorMessage);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteProduct(
        [FromServices] DeleteProductFunction function,
        [FromQuery, Required] int productId,
        CancellationToken cancellationToken)
    {
        var (isDelete, errorMessage) = await function(productId, cancellationToken);
        return isDelete
            ? Ok()
            : BadRequest(errorMessage);
    }
}
