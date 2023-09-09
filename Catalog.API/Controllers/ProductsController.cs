using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;
using Catalog.API.Abstractions;
using Catalog.API.Application.Contracts;
namespace Catalog.API.Controllers;

public class ProductsController : ApiController
{
    IRepository<Product , int > repository;
    public ProductsController()
    {
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
    {
        //? fetch data from DB
    return await Task.FromResult(Ok());
    }


    [HttpPost]
    public async Task<ActionResult<Product>> AddProductsAsync(
        [FromBody]Product product )
    {
    return await Task.FromResult(Ok());
    }
}
