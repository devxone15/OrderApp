using OrdersApp.Domain.Core.Entities;
using System.Collections.Generic;
using OrdersApp.Domain.Interfaces;

namespace OrdersApp.Infrastructure.Business.Providers
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductRepository _productRepository;

        public ProductProvider(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<ProductInOrder> GetProducts(int orderId)
        {
            return _productRepository.Get(orderId);
        }
    }
}