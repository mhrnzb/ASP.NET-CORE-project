// using System.ComponentModel.DataAnnotations;
using Catalog.API.Abstractions;

namespace Catalog.API.Models;

//? Anemic Model
public class Product : Entity<int>
{
    //? Guid, Identity, Custom Value(string)
    // public int Id { get; set; }
    // [Required]
    public string Name { get; set; }
    public int Price { get; set; }
    public string? Description { get; set; }
}
