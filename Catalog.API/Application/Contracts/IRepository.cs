
namespace Catalog.API.Application.Contracts
{ 
    //? product/customer
    public interface IRepository<TEntity>
    { 
        Task AddAsync(TEntity entity);

        Task <IEnumerable<TEntity>> GetEntitiesAsync();
    }
}