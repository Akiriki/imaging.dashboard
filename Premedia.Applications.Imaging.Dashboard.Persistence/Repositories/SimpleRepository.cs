using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Premedia.Applications.Imaging.Dashboard.Core.Models;
using Premedia.Applications.Imaging.Dashboard.Persistence;
using Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;

public class SimpleRepository<T> : RepositoryBase<T>, IRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;

    public SimpleRepository(ImagingDashboardDbContext dbContext) : base(dbContext)
    {
        _dbSet = dbContext.Set<T>();
    }

    public async Task<List<TResult>> GetAllAndSelectAsync<TResult>(Expression<Func<T, TResult>> selector,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool includeDeleted = false)
    {
        IQueryable<T> query = _dbSet;

        return await base.GetAllAndSelectAsync(query, selector, include, orderBy).ConfigureAwait(false);
    }

    public async Task<List<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool includeDeleted = false)
    {
        IQueryable<T> query = _dbSet;

        return await base.GetAllAsync(query, include, orderBy).ConfigureAwait(false);
    }

    public async Task<List<TResult>> GetMultipleAndSelectAsync<TResult>(Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool includeDeleted = false)
    {
        IQueryable<T> query = _dbSet;

        return await base.GetMultipleAndSelectAsync(query, selector, predicate, include, orderBy).ConfigureAwait(false);
    }

    public async Task<List<T>> GetMultipleAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool includeDeleted = false)
    {
        IQueryable<T> query = _dbSet;

        return await base.GetMultipleAsync(query, predicate, include, orderBy).ConfigureAwait(false);
    }

    public async Task<TResult> GetFirstOrDefaultAndSelectAsync<TResult>(Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool includeDeleted = false)
    {
        IQueryable<T> query = _dbSet;

        return await base.GetFirstOrDefaultAndSelectAsync(query, selector, predicate, include, orderBy)
            .ConfigureAwait(false);
    }

    public async Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool includeDeleted = false)
    {
        IQueryable<T> query = _dbSet;

        return await base.GetFirstOrDefaultAsync(query, predicate, include, orderBy).ConfigureAwait(false);
    }

    public async Task<PagedResultModel<T>> GetMultipleByQuery(QueryBase command, Func<IQueryable<T>,
            IIncludableQueryable<T, object>>? include = null,
        Expression<Func<T, bool>>? predicate = null,
        bool includeDeleted = false)
    {
        IQueryable<T> query = _dbSet;
        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return await base.GetMultipleByQuery(query, command, include).ConfigureAwait(false);
    }


    public async Task<bool> ExistAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.AnyAsync(predicate).ConfigureAwait(false);
    }
}