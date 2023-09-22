namespace Catalog.API.Application.Contracts;

public interface IEntity<TId>
{
    TId Id {get; set;}
}
