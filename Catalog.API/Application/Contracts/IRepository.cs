namespace Catalog.API.Application.Contracts;

//? Product/Customer
public interface IRepository<TEntity, TId>
where TEntity : IEntity<TId>
{
   Task AddAsync(TEntity entity);
   Task UpdateAsync(TEntity entity);
   Task DeleteAsync(TEntity entity);
   Task<TEntity?> GetByIdAsync(TId id);

   Task<IEnumerable<TEntity>> GetEntitiesAsync();
   Task<IEnumerable<TEntity>> FilterAsync();
}
