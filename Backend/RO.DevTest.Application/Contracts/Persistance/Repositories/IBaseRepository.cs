using System.Linq.Expressions;

namespace RO.DevTest.Application.Contracts.Persistance.Repositories;

public interface IBaseRepository<T> where T : class
{

    /// <summary>
    /// Creates a new entity in the database
    /// </summary>
    Task<T> CreateAsync(T entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Finds the first entity that matches with the pradicate.
    /// </summary>
    Task<T?> GetAsync(
        Expression<Func<T, bool>> predicate,
        params Expression<Func<T, object>>[] includes
    );

    /// <summary>
    /// Updates an entity entry on the database
    /// </summary>
    Task UpdateAsync(T entity);

    /// <summary>
    /// Deletes one entry from the database
    /// </summary>
    Task DeleteAsync(T entity);

    Task<T?> GetByIdAsync(Guid id);

    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);

    Task SaveAsync(CancellationToken cancellationToken = default);

}
