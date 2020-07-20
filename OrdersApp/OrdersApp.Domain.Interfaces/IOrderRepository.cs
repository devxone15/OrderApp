using System;
using System.Collections.Generic;
using OrdersApp.Domain.Core.Entities;

namespace OrdersApp.Domain.Interfaces
{
    public interface IOrderRepository : IDisposable
    {
        IEnumerable<Order> GetAll();
    }
}
