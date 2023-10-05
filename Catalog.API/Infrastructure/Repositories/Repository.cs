using Catalog.API.Application.Contracts;
using Catalog.API.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Repositories;

public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
where TEntity : Entity<TId>
{
    private DbContext _context;
    private DbSet<TEntity> _set;

    protected Repository(DbContext context)
    {
        _context = context;
        _set = _context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _set.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _set.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await _set.FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetEntitiesAsync()
    {
        return await _set.ToListAsync();
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _set.Update(entity);
        await _context.SaveChangesAsync();
    }
}
