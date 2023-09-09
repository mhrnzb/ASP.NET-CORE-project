using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    public ProductsController()
    {
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
    {
    return await Task.FromResult(Ok());
    }


    [HttpPost]
    public async Task<ActionResult<Product>> AddProductsAsync(
        [FromBody]Product product )
    {
    return await Task.FromResult(Ok());
    }
}
