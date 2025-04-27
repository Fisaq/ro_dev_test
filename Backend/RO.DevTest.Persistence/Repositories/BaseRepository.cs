using Microsoft.EntityFrameworkCore;
using RO.DevTest.Application.Contracts.Persistance.Repositories;
using RO.DevTest.Domain.Entities;
using System.Linq.Expressions;

namespace RO.DevTest.Persistence.Repositories;

public class BaseRepository<T>(DefaultContext defaultContext) : IBaseRepository<T> where T : class
{
    private readonly DefaultContext _defaultContext = defaultContext;

    protected DefaultContext Context => _defaultContext;

    public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default)
    {
        await Context.Set<T>().AddAsync(entity, cancellationToken);
        await Context.SaveChangesAsync(cancellationToken);
        return entity;
    }

    public async Task UpdateAsync(T entity)
    {
        Context.Set<T>().Update(entity);
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        Context.Set<T>().Remove(entity);
        await Context.SaveChangesAsync();
    }

    public async Task<T?> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes)
    {
        return await GetQueryWithIncludes(predicate, includes).FirstOrDefaultAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await Context.Set<T>().FindAsync(id);
    }

    public async Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await Context.Set<T>().ToListAsync(cancellationToken);
    }

    public async Task SaveAsync(CancellationToken cancellationToken = default)
    {
        await Context.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<T>> GetAllWithIncludeAsync(Func<IQueryable<T>, IQueryable<T>> include, CancellationToken cancellationToken = default)
    {
        IQueryable<T> query = Context.Set<T>();

        if (include != null)
        {
            query = include(query);
        }

        return await query.ToListAsync(cancellationToken);
    }



    /// <summary>
    /// Generates a filtered <see cref="IQueryable{T}"/>, based on its
    /// <paramref name="predicate"/> and <paramref name="includes"/>, including
    /// the data requested
    /// </summary>
    /// <param name="predicate">
    /// The <see cref="Expression"/> to use as filter
    /// </param>
    /// <param name="includes">
    /// The <see cref="Expression"/> to use as include
    /// </param>
    /// <returns>
    /// The generated <see cref="IQueryable{T}"/>
    /// </returns>
    private IQueryable<T> GetQueryWithIncludes(
        Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includes
    )
    {
        IQueryable<T> baseQuery = GetWhereQuery(predicate);

        foreach (Expression<Func<T, object>> include in includes)
        {
            baseQuery = baseQuery.Include(include);
        }

        return baseQuery;
    }

    /// <summary>
    /// Generates an <see cref="IQueryable"/> based on
    /// the <paramref name="predicate"/>
    /// </summary>
    /// <param name="predicate">
    /// An <see cref="Expression"/> representing a filter
    /// of it
    /// </param>
    /// <returns>S
    /// The <see cref="IQueryable{T}"/>
    /// </returns>
    private IQueryable<T> GetWhereQuery(Expression<Func<T, bool>> predicate)
    {
        IQueryable<T> baseQuery = Context.Set<T>();

        if (predicate is not null)
        {
            baseQuery = baseQuery.Where(predicate);
        }

        return baseQuery;
    }

}
