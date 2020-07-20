using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OrdersApp.Dtos;
using OrdersApp.Infrastructure.Business.Providers;

namespace OrdersApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProvider _orderProvider;
        private readonly IProductProvider _productProvider;
        private readonly IMapper _mapper;

        public OrderController(IOrderProvider orderProvider, IProductProvider productProvider, IMapper mapper)
        {
            _orderProvider = orderProvider;
            _productProvider = productProvider;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var orders = _orderProvider.GetOrders();
            var result = _mapper.Map<List<OrderDto>>(orders);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var products = _productProvider.GetProducts(id);
            var result = _mapper.Map<List<ProductDto>>(products);
            return Ok(result);
        }
    }
}
