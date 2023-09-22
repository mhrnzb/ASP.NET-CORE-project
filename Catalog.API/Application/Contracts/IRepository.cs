namespace Catalog.API.Application.Contracts;

//? Product/Customer
public interface IRepository<TEntity, TId>
where TEntity : IEntity<TId>
{
   Task AddAsync(TEntity entity);
   Task<IEnumerable<TEntity>> GetEntitiesAsync();
}
