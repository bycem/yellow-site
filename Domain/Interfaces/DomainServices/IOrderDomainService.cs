﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interfaces.DomainServices
{
    public interface IOrderDomainService
    {
        Task<Order> GetByIdForCurrentCustomerAsync(Guid id);
    }
}
