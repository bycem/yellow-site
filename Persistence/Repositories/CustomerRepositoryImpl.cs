using Domain.Interfaces.Repositories;
using Domain.Models;

namespace Persistence.Repositories
{
    public class CustomerRepositoryImpl : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }
    }
}
