using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;
using Catalog.API.Abstractions;
using Catalog.API.Application.Contracts;
using Catalog.API.Application.Dtos;
using AutoMapper;

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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProductsAsync()
    {
        //? Fetch Data From DB
        var products = await _repository.GetEntitiesAsync();

        return Ok(products);
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

    // [HttpPost]
    // public async Task<ActionResult<Product>> AddProductAsync(
    //     [FromBody] Product product)
    // {
    //     await _repository.AddAsync(product);

    //     return await Task.FromResult(Ok(product));
    // }


    // [HttpPost]
    // public async Task<ActionResult<Product>> AddProductAsync(
    //     [FromBody] ProductForAddDto productForAddDto)
    // {
    //     //? Conversion
    //     var product = new Product
    //     {
    //         Name = productForAddDto.Name,
    //         Price = productForAddDto.Price,
    //         Description = productForAddDto.Description,
    //     };

    //     await _repository.AddAsync(product);

    //     //? Conversion
    //     var productDto = new ProductDto(
    //         product.Id,
    //         product.Name,
    //         product.Price,
    //         product.Description
    //     );

    //     return await Task.FromResult(Ok(productDto));
    // }

    [HttpPost]
    public async Task<ActionResult<Product>> AddProductAsync(
            [FromBody] ProductForAddDto productForAddDto)
    {
        //? Invariant Rules
        // if (!string.IsNullOrEmpty(productForAddDto.Name))
        // {
        //     return BadRequest("Name is a required.");
        // }

        // if (!(productForAddDto.Name.Length < 2))
        // {
        //     return BadRequest("Name minimum lenght is 3.");
        // }

        // if (!(productForAddDto.Name.Length > 50))
        // {
        //     return BadRequest("Name maximum lenght is 50.");
        // }

        //? Conversion
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
        //? Invariant Rules
        // if (!string.IsNullOrEmpty(productForUpdateDto.Name))
        // {
        //     return BadRequest("Name is a required.");
        // }

        // if (!(productForUpdateDto.Name.Length < 2))
        // {
        //     return BadRequest("Name minimum lenght is 3.");
        // }

        // if (!(productForUpdateDto.Name.Length > 50))
        // {
        //     return BadRequest("Name maximum lenght is 50.");
        // }

        //? Conversion
        // var product = _mapper.Map<Product>(productForUpdateDto);
        // product.Id = id;

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
