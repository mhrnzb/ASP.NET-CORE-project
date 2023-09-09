
namespace Catalog.API.Application.Contracts
{ 
    //? product/customer
    public interface IRepository<TEntity , TId>
    where TEntity : IEntity<TId>
    { 

        Task AddAsync(TEntity entity);

        Task <IEnumerable<TEntity>> GetEntitiesAsync();
    }
}