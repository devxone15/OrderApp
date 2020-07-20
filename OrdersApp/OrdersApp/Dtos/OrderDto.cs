using System;

namespace OrdersApp.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}