
using Catalog.API.Application.Contracts;
using Catalog.API.Models;

namespace Catalog.API.Infrastructure
{
    public class ProductRepository : Repository<Product , int> , IProductRepository
    {
        
    }
}