namespace Domain.Abstractions
{
    public interface IRepository<T> where T : IEntity
    {
        Task<T> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(T entity);
        Task UpdateAsync(T entity);
    }
}
