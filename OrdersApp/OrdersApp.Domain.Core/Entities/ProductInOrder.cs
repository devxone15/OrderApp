namespace OrdersApp.Domain.Core.Entities
{
    public class ProductInOrder : BaseEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}