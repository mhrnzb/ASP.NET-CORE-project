using Catalog.API.Application.Contracts;
using Catalog.API.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq.Dynamic.Core;
using Catalog.API.Application.Contracts.Data;
using Catalog.API.Application.Dtos.Common;

namespace Catalog.API.Infrastructure.Repositories;

public abstract class Repository<TEntity, TId> : IRepository<TEntity, TId>
where TEntity : Entity<TId>
{
    // private const int Default_Page_Size = 10;
    // private const int Max_Page_Size = 100;

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

    public async Task<IEnumerable<TEntity>> FilterAsync(
        Expression<Func<TEntity, bool>> predicate)
    {
        return await _set.Where(predicate).ToListAsync();
    }

    // public async Task<IEnumerable<TEntity>> FilterAsync(string predicate)
    // {
    //     return await _set.Where(predicate).ToListAsync();
    // }

    // public async Task<IEnumerable<TEntity>> FilterAsync(string? predicate, 
    //   int pageSize, 
    //   int pageIndex)
    // {
    //     return await _set
    //                     .Where(predicate)
    //                     .Skip((pageIndex-1)*pageSize)
    //                     .Take(pageSize)
    //                     .ToListAsync();
    // }

    // public async Task<IEnumerable<TEntity>> FilterAsync(FilterData data)
    // {
    //     var pageSize = Default_Page_Size;//?Default Page Size

    //     if (data.PageSize.HasValue)
    //     {
    //         if (data.PageSize > Max_Page_Size) //? Max Page Size
    //         {
    //             pageSize = Max_Page_Size;
    //         }

    //         if (data.PageSize < 0)
    //         {
    //             pageSize = Default_Page_Size;
    //         }
    //     }

    //     var pageIndex = 1;

    //     if (data.PageIndex.HasValue)
    //     {
    //         pageIndex = data.PageIndex.Value;
    //     }

    //     if (string.IsNullOrEmpty(data.Filter))
    //     {
    //         return await _set
    //                         .Skip((pageIndex - 1) * pageSize)
    //                         .Take(pageSize)
    //                         .ToListAsync();
    //     }

    //     return await _set
    //                     .Where(data.Filter)
    //                     .Skip((pageIndex - 1) * pageSize)
    //                     .Take(pageSize)
    //                     .ToListAsync();
    // }

    // public async Task<IEnumerable<TEntity>> FilterAsync(FilterData data)
    // {
    //     return await _set
    //                     .Filter(data.Filter)
    //                     .PageAsync(data.PageSize, data.PageIndex);
    // }

    public async Task<PagedList<TEntity>> FilterAsync(FilterData data)
    {
        return await _set
                        .Filter(data.Filter)
                        .PageAsync(data.PageSize, data.PageIndex);
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
