using Core.Entities;
using Core.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetCategory(
        [FromServices] GetCategoryFunction getCategoryFunction,
        [FromQuery] int categoryId,
        CancellationToken cancellationToken)
    {
        var (category, categories) = await getCategoryFunction(categoryId, cancellationToken);
        return category is not null
            ? Ok(category)
            : Ok(categories);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory(
        [FromServices] AddCategoryFunction addCategoryFunction,
        [FromBody] AddCategoryDTO categoryDTO,
        CancellationToken cancellationToken)
    {
        var (category, errorMessage) = await addCategoryFunction(categoryDTO, cancellationToken);
        return string.IsNullOrEmpty(errorMessage)
            ? Ok(category)
            : StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateCategory(
        [FromServices] UpdateCategoryFunction updateCategoryFunction,
        [FromBody] Category categoryEdit,
        CancellationToken cancellationToken)
    {
        var (category, errorMessage) = await updateCategoryFunction(categoryEdit, cancellationToken);
        return string.IsNullOrEmpty(errorMessage)
            ? Ok(category)
            : StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCategory(
        [FromServices] DeleteCategoryFunction deleteCategoryFunction,
        [FromQuery, Required] int categoryId,
        CancellationToken cancellationToken)
    {
        var (isDelete, errorMessage) = await deleteCategoryFunction(categoryId, cancellationToken);
        return isDelete
            ? Ok()
            : StatusCode(StatusCodes.Status500InternalServerError, errorMessage);
    }
}
