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
    public IEnumerable<Product> Get()
    {
    return Ok();
    }
}
