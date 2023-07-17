using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;
using Premedia.Applications.Imaging.Dashboard.Core.Models;
using Premedia.Applications.Imaging.Dashboard.Persistence;

public class RepositoryBase<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    public RepositoryBase(ImagingDashboardDbContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    public async Task<List<TResult>> GetAllAndSelectAsync<TResult>(IQueryable<T> query,
        Expression<Func<T, TResult>> selector,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        if (include != null)
        {
            query = include(query).AsSplitQuery();
        }

        if (orderBy != null)
        {
            return await orderBy(query).Select(selector).ToListAsync().ConfigureAwait(false);
        }


        return await query.Select(selector).ToListAsync().ConfigureAwait(false);
    }

    public async Task<List<T>> GetAllAsync(IQueryable<T> query,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        if (include != null)
        {
            query = include(query).AsSplitQuery();
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync().ConfigureAwait(false);
        }

        return await query.ToListAsync().ConfigureAwait(false);
    }

    public async Task<List<TResult>> GetMultipleAndSelectAsync<TResult>(IQueryable<T> query,
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        if (include != null)
        {
            query = include(query).AsSplitQuery();
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (orderBy != null)
        {
            return await orderBy(query).Select(selector).ToListAsync().ConfigureAwait(false);
        }

        return await query.Select(selector).ToListAsync().ConfigureAwait(false);
    }

    public async Task<List<T>> GetMultipleAsync(IQueryable<T> query, Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        if (include != null)
        {
            query = include(query).AsSplitQuery();
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync().ConfigureAwait(false);
        }

        return await query.ToListAsync().ConfigureAwait(false);
    }

    public async Task<TResult> GetFirstOrDefaultAndSelectAsync<TResult>(IQueryable<T> query,
        Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        if (include != null)
        {
            query = include(query).AsSplitQuery();
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (orderBy != null)
        {
            return await orderBy(query).Select(selector).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        return await query.Select(selector).FirstOrDefaultAsync().ConfigureAwait(false);
    }

    public async Task<T> GetFirstOrDefaultAsync(IQueryable<T> query, Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        if (include != null)
        {
            query = include(query).AsSplitQuery();
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (orderBy != null)
        {
            return await orderBy(query).FirstOrDefaultAsync().ConfigureAwait(false);
        }

        return await query.FirstOrDefaultAsync().ConfigureAwait(false);
    }


    public async Task<PagedResultModel<T>> GetMultipleByQuery(IQueryable<T> query, QueryBase command,
        Func<IQueryable<T>,
            IIncludableQueryable<T, object>>? include = null)
    {
        List<T> list = null;
        var count = 0;

        if (include != null)
        {
            query = include(query).AsSplitQuery();
        }

        if (!string.IsNullOrEmpty(command.SearchString))
        {
            list = query.ToList();
            var newList = new List<T>();
            foreach (var prop in command.PropListForSearch)
            {
                var propDescriptor = TypeDescriptor.GetProperties(typeof(T)).Find(prop, true);
                if (propDescriptor != null)
                {
                    newList.AddRange(list.Where(x =>
                            propDescriptor.GetValue(x)!.ToString()!.ToLower().Contains(command.SearchString.ToLower()))
                        .ToList());
                }
            }

            list = newList.Distinct().ToList();
        }

        list ??= query.ToList();
        count = list.Count;
        if (!string.IsNullOrEmpty(command.OrderBy))
        {
            var propDescriptor = TypeDescriptor.GetProperties(typeof(T)).Find(command.OrderBy, true);
            if (propDescriptor != null)
            {
                list = command.ShouldSortDescending != true
                    ? list.OrderBy(x => propDescriptor.GetValue(x)).ToList()
                    : list.OrderByDescending(x => propDescriptor.GetValue(x)).ToList();
            }
        }

        if (command.PageSize != null && command.PageIndex != null)
        {
            if (list != null)
            {
                list = list.Skip(command.PageIndex ?? 1).Take(command.PageSize ?? 10).ToList();
            }
        }

        return new PagedResultModel<T>
        {
            ItemList = list,
            ItemCount = count
        };
    }


    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity).ConfigureAwait(false);
    }

    public async Task AddRangeAsync(IEnumerable<T> entities)
    {
        await _dbSet.AddRangeAsync(entities).ConfigureAwait(false);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public void Remove(T entity)
    {
        _dbSet.Remove(entity);
    }

    public void RemoveRange(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }
}
