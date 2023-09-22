using Catalog.API.Infrastructure.Configurations;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure;

public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options)
        :base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //?
        // modelBuilder.ApplyConfiguration(new ProductConfiguration());
        // modelBuilder.ApplyConfiguration(new CutomerConfiguration());
        // modelBuilder.ApplyConfiguration(new OrderConfiguration());

        //? DRY
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public DbSet<Product> Products { get; set; }
}
