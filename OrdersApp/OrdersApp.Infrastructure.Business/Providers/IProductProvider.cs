using System.Collections.Generic;
using OrdersApp.Domain.Core.Entities;

namespace OrdersApp.Infrastructure.Business.Providers
{
    public interface IProductProvider
    {
        IEnumerable<ProductInOrder> GetProducts(int orderId);
    }
}