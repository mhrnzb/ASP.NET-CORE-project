using Catalog.API.Application.Contracts;
namespace Catalog.API.Abstractions
{
    public class Entity<TId> : IEntity<TId>
    {
        public TId? Id { get; set; }
    }
}