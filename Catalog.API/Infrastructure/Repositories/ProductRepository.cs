using Catalog.API.Application.Contracts;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Repositories;

public sealed class ProductRepository : Repository<Product, int>, IProductRepository
{
    public ProductRepository(DbContext context) : base(context)
    {
        public ProductRepository(DbContext context) : base(context)

        {

        }
    }
}
