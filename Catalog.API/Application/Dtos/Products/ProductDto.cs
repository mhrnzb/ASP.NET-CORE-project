namespace Catalog.API.Application.Dtos;

public sealed record ProductDto(
    int Id,
    string Name,
    int Price,
    string Description
);
