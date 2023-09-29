namespace Catalog.API.Application.Dtos;

    public sealed record class ProductDto(
    int Id,
    string Name,
    int Price,
    string Description
    );