namespace Catalog.API.Application.Dtos;

//? Data Transfer Object (DTO)
//? Immutable
// public sealed class ProductForAddDto
// {
//     [Required]
//     public string Name { get; init; }
//     public int Price { get; init; }
//     public string Description { get; init; }

//     public ProductForAddDto(string name, int price, string description)
//     {
//         Name = name; Price = price; Description = description;
//     }
// }

public sealed record ProductForAddDto(
    string Name,
    int Price,
    string Description
);
