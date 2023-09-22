using Catalog.API.Abstractions;

namespace Catalog.API.Models;

public class Customer : Entity<Guid>
{
    // public new Guid Id { get; set; }
    public string? FullName { get; set; }

    //? Other Properties

    public Customer()
    {
        Id = Guid.NewGuid();
    }
}
