namespace Domain.Abstractions
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        Task<T> GetById(Guid id);
        Task<Guid> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
