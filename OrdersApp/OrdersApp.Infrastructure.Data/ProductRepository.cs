using OrdersApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using OrdersApp.Domain.Core.Entities;

namespace OrdersApp.Infrastructure.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _db;

        public ProductRepository(ApplicationContext context)
        {
            _db = context;
        }

        public IEnumerable<ProductInOrder> Get(int orderId)
        {
            var products = _db.ProductsInOrders.ToList()
                .Where(po => po.OrderId == orderId)
                .Join(_db.Products,
                    po => po.ProductId,
                    p => p.Id,
                    (po, p) =>
                        new ProductInOrder
                        {
                            Id = po.Id,
                            OrderId = po.OrderId,
                            ProductId = po.ProductId,
                            Product = new Product
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Price = p.Price
                            },
                            ProductCount = po.ProductCount
                        });

            return products;
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
