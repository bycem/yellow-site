using Domain.Interfaces.Services;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Services.CurrentCustomer
{

    public class CurrentCustomerImpl : ICurrentCustomer
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly ApplicationDbContext _context;

        public CurrentCustomerImpl(
            ICurrentUserService currentUserService,
            ApplicationDbContext context)
        {
            _currentUserService = currentUserService;
            _context = context;
        }

        public async Task<Customer> GetAsync()
        {
            var currentUserId = await _currentUserService.GetUserIdAsync();
            var customer = await _context.Customers.FirstOrDefaultAsync(x => x.UserId == currentUserId);
            if (customer == null)
            {
                throw new InvalidOperationException("Customer not found");
            }

            return customer;
        }
    }
}
