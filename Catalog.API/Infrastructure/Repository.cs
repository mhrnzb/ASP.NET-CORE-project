using Catalog.API.Application.Contracts;
using Catalog.API.Abstractions;

namespace Catalog.API.Infrastructure
{
    public class Repository<TEntity , TId> : IRepository<TEntity , TId>
    where TEntity : IEntity<TId>
   {

    public Task AddAsync(TEntity entity){
        throw new NotImplementedException();
    }


    public Task<IEnumerable<TEntity>> GetEntitiesAsync(){
        throw new NotImplementedException();
    }






   }
}