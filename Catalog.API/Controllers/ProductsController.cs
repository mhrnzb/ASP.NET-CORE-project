using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;
using Catalog.API.Abstractions;
using Catalog.API.Application.Contracts;
using Catalog.API.Application.Dtos;

namespace Catalog.API.Controllers;


public class ProductsController : ApiController
{
    // IRepository<Product, int> repository;
    private readonly IProductRepository _repository;

    public ProductsController(IProductRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
    {
        //? Fetch Data From DB
        var products = await _repository.GetEntitiesAsync();

        return await Task.FromResult(Ok(products));
    }
 
    // [HttpPost]
    // public async Task<ActionResult<Product>> AddProductAsync(
    //     [FromBody] Product product)
    // {
    //     await _repository.AddAsync(product);

    //     return await Task.FromResult(Ok(product));
    // }


    [HttpPost]
    public async Task<ActionResult<Product>> AddProductAsync(
        [FromBody] ProductForAddDto productDto)
    {
        var product = new Product
        {
            Name = productDto.Name,
            Price = productDto.Price,
            Description = productDto.Description
        };

        await _repository.AddAsync(product);

        return await Task.FromResult(Ok(product));
    }
}
