using System.Linq.Expressions;
using Catalog.API.Application.Contracts.Data;
using Catalog.API.Application.Dtos.Common;

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
   //? Func<TEntity, bool>
   //? Expression<Func<TEntity, bool>>
   Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicate);
   // Task<IEnumerable<TEntity>> FilterAsync(string predicate);
   // Task<IEnumerable<TEntity>> FilterAsync(
   //    string? predicate, 
   //    int pageSize, 
   //    int pageIndex);
   // Task<IEnumerable<TEntity>> FilterAsync(FilterData data);
   Task<PagedList<TEntity>> FilterAsync(FilterData data);

}
