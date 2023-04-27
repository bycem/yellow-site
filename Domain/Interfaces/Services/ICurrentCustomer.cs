using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface ICurrentCustomer
    {
        Task<Customer> GetAsync();
    }
}
