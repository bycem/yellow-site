using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        public Task<Guid> CreateAsync(Order order);
        public Task UpdateAsync(Order order);
    }
}
