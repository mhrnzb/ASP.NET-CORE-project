namespace Catalog.API.Application.Dtos;

public sealed record ProductForUpdateDto(
    string Name,
    int Price,
    string Description
);
