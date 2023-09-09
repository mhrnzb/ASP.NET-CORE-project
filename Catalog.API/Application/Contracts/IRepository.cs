using Catalog.API.Abstractions;
namespace Catalog.API.Application.Contracts
{ 
    //? product/customer
    public interface IRepository<TEntity , TId>
    where TEntity : Entity<TId>
    { 

        Task AddAsync(TEntity entity);

        Task <IEnumerable<TEntity>> GetEntitiesAsync();
    }
}