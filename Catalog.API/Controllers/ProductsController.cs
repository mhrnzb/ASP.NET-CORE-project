using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;
using Catalog.API.Abstractions;
namespace Catalog.API.Controllers;


public class ProductsController : ApiController
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
