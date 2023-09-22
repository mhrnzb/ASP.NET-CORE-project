using Catalog.API.Application.Contracts;
using Catalog.API.Abstractions;

namespace Catalog.API.Infrastructure;

//? Fake
public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
where TEntity : Entity<TId>
{
    public Task AddAsync(TEntity entity)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<TEntity>> GetEntitiesAsync()
    {
        throw new NotImplementedException();
    }
}
