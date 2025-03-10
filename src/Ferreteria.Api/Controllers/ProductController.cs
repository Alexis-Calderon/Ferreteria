using System.Threading.Tasks;

using Ferreteria.Application.DTOs.Product;
using Ferreteria.Application.Interfaces;
using Ferreteria.Domain.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ferreteria.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpGet(Name = "GetAllProducts")]
    [ProducesResponseType<GetAllResponse<ProductResponseDto>>(StatusCodes.Status200OK)]
    [ProducesDefaultResponseType]
    [Produces("application/json")]
    public async Task<IActionResult> GetAll([FromQuery] string? filter, [FromQuery] int page = 1, [FromQuery] int pageSize = 10)
    {
        var products = await _productService.GetAllAsync(filter, page, pageSize);
        return Ok(products);
    }
}