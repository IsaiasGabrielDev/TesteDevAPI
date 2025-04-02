using Core.Entities;
using Core.Services.ProductServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        CancellationToken cancellationToken)
    {
        var (products, product) = await function(productId, cancellationToken);
        return product is not null
            ? Ok(product)
            : Ok(products);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct(
        [FromServices] AddProductFunction function,
        [FromBody] AddProductDTO addProductDTO,
        CancellationToken cancellation)
    {
        var (product, errorMessage) = await function(addProductDTO, cancellation);
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
        var (updatedProduct, errorMessage) = await function(product, cancellationToken);
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
