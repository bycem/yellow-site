using System.Linq.Expressions;

namespace Domain.Abstractions
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<List<T>> ListAsync(Expression<Func<T, bool>> predicate);
        Task<Guid> CreateAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
