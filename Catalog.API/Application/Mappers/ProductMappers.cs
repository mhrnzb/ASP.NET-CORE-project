using AutoMapper;
using Catalog.API.Application.Dtos;
using Catalog.API.Models;

namespace Catalog.API.Application.Mappers;

public class ProductMappers : Profile
{
    public ProductMappers()
    {
        CreateMap<ProductForUpdateDto, Product>();
        CreateMap<Product, ProductDto>();
    }
}
