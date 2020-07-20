using System;

namespace OrdersApp.Domain.Core.Entities
{
    public class Order : BaseEntity
    {
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
    }
}