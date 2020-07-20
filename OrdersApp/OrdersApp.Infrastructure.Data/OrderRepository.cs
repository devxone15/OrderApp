using System;
using OrdersApp.Domain.Core.Entities;
using OrdersApp.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OrdersApp.Infrastructure.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationContext _db;

        public OrderRepository(ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<Order> GetAll()
        {
            return _db.Orders.ToList();
        }

        #region Dispose

        private bool _disposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    _db.Dispose();
            _disposed = true;
        }

        #endregion
    }
}