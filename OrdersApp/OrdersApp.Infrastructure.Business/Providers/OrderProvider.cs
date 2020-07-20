using System.Collections.Generic;
using OrdersApp.Domain.Core.Entities;
using OrdersApp.Domain.Interfaces;

namespace OrdersApp.Infrastructure.Business.Providers
{
    public class OrderProvider : IOrderProvider
    {
        private readonly IOrderRepository _orderRepository;

        public OrderProvider(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public IEnumerable<Order> GetOrders()
        {
            return _orderRepository.GetAll();
        }
    }
}
