using Microsoft.EntityFrameworkCore.Query;
using Premedia.Applications.Imaging.Dashboard.Core.Models;
using System.Linq.Expressions;

namespace Premedia.Applications.Imaging.Dashboard.Persistence.Contracts;

public interface IRepository<T> where T : class
{
    Task<bool> ExistAsync(Expression<Func<T, bool>> predicate);
    Task AddAsync(T entity);
    Task AddRangeAsync(IEnumerable<T> entities);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Remove(T entity);
    void RemoveRange(IEnumerable<T> entities);

    Task<List<TResult>> GetAllAndSelectAsync<TResult>(Expression<Func<T, TResult>> selector,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool includeDeleted = false);

    Task<List<T>> GetAllAsync(Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool includeDeleted = false);

    Task<List<TResult>> GetMultipleAndSelectAsync<TResult>(Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool includeDeleted = false);

    Task<List<T>> GetMultipleAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool includeDeleted = false);

    Task<TResult> GetFirstOrDefaultAndSelectAsync<TResult>(Expression<Func<T, TResult>> selector,
        Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool includeDeleted = false);

    Task<T> GetFirstOrDefaultAsync(Expression<Func<T, bool>>? predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
        bool includeDeleted = false);

    Task<PagedResultModel<T>> GetMultipleByQuery(QueryBase command,
        Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null,
        Expression<Func<T, bool>>? predicate = null,
        bool includeDeleted = false);
}