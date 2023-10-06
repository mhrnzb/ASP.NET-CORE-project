using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;
using Catalog.API.Abstractions;
using Catalog.API.Application.Contracts;
using Catalog.API.Application.Dtos.Products;
using AutoMapper;
using Catalog.API.Application.Dtos.Common;
using Catalog.API.Application.Contracts.Data;
using System.Text.Json;

namespace Catalog.API.Controllers;

public class ProductsController : ApiController
{
    private IMapper _mapper;
    private readonly IProductRepository _repository;

    public ProductsController(
        IProductRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    // [HttpGet]
    // public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
    // {
    //     //? Fetch Data From DB
    //     var products = await _repository.GetEntitiesAsync();

    //     return Ok(products);
    // }

    // [HttpGet("filter")]
    // public async Task<ActionResult<IEnumerable<ProductDto>>> FilterProductsAsync(
    //     [FromQuery] string? filter,
    //     [FromQuery] int pageSize,
    //     [FromQuery] int pageIndex)
    // {
    //     //? Price > 150
    //     // var products = await _repository.FilterAsync(product => product.Price > 150);
    //     var products = await _repository.FilterAsync(filter, pageSize, pageIndex);

    //     var productsDto = _mapper.Map<IEnumerable<ProductDto>>(products);

    //     return Ok(productsDto);
    // }

    [HttpGet("filter")]
    public async Task<ActionResult<IEnumerable<ProductDto>>> FilterProductsAsync(
        [FromQuery]FilterDataDto data)
    {
        var filterData = _mapper.Map<FilterData>(data);

        var productsPagedList = await _repository.FilterAsync(filterData);

        var productsDto = _mapper.Map<IEnumerable<ProductDto>>(productsPagedList.Items);

        //? Meta Data
        Response.Headers.Add("X-PagingData", JsonSerializer.Serialize(productsPagedList.Paging));

        //? Pay load
        return Ok(productsDto);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDto>> GetProductByIdAsync([FromRoute] int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product is null)
        {
            return NotFound($"Invalid ProductId : {id}");
        }

        var productDto = _mapper.Map<ProductDto>(product);

        return Ok(productDto);
    }

    [HttpPost]
    public async Task<ActionResult<Product>> AddProductAsync(
            [FromBody] ProductForAddDto productForAddDto)
    {
        var product = _mapper.Map<Product>(productForAddDto);

        await _repository.AddAsync(product);

        //? Conversion
        var productDto = _mapper.Map<ProductDto>(product);

        return Ok(productDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProductAsync(
            [FromRoute] int id,
            [FromBody] ProductForUpdateDto productForUpdateDto)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product is null)
        {
            return BadRequest($"Invalid ProductId : {id}");
        }

        product.Name = productForUpdateDto.Name;
        product.Price = productForUpdateDto.Price;
        product.Description = productForUpdateDto.Description;

        await _repository.UpdateAsync(product);

        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProductAsync([FromRoute] int id)
    {
        var product = await _repository.GetByIdAsync(id);

        if (product is null)
        {
            return BadRequest($"Invalid ProductId : {id}");
        }

        //? Check Business Rules

        await _repository.DeleteAsync(product);

        return Ok();
    }

}
