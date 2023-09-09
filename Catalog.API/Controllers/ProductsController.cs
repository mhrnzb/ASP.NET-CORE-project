using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;
using Catalog.API.Abstractions;
using Catalog.API.Application.Contracts;
namespace Catalog.API.Controllers;

public class ProductsController : ApiController
{
    //IRepository<Product , int > repository;

    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository){
        _repository = repository;

    }
    public ProductsController()
    {
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
    {
        //? fetch data from DB
        var products = await _repository.GetEntitiesAsync();
    return await Task.FromResult(Ok(products));
    }


    [HttpPost]
    public async Task<ActionResult<Product>> AddProductsAsync(
        [FromBody]Product product )
    {
        await _repository.AddAsync(product);
        return await Task.FromResult(Ok(product));
    }
}
