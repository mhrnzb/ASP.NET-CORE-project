namespace Catalog.API.Application.Dtos.Products;

public sealed record ProductDto(
    int Id,
    string Name,
    int Price,
    string Description
);
