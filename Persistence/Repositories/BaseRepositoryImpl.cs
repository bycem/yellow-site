using Domain.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories
{
    public class BaseRepositoryImpl<T> : IRepository<T> where T : class, IAggregateRoot
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<T> _dbSet;

        public BaseRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<T> GetById(Guid id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (result == null)
            {
                throw new ArgumentException($"{nameof(T)} not found by following Id:{{id}}");
            }

            return result;
        }

        public async Task<Guid> CreateAsync(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
