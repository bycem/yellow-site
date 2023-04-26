using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<Guid> CreateAsync(Customer customer);
    }
}
