using System;
using System.Collections.Generic;
using OrdersApp.Domain.Core.Entities;

namespace OrdersApp.Domain.Interfaces
{
    public interface IProductRepository : IDisposable
    {
        IEnumerable<ProductInOrder> Get(int id);
    }
}