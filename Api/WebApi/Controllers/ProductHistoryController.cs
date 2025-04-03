using Core.Services.ProductHistoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class ProductHistoryController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProductHistory(
            [FromServices] GetProductHistoryFunction getProductHistory,
            [FromQuery] int categoryId,
            [FromQuery] int userId,
            CancellationToken cancellationToken)
        {
            var request = new GetProductHistoryRequest(categoryId, userId);
            var result = await getProductHistory(request, cancellationToken);
            return Ok(result);
        }
    }
}
