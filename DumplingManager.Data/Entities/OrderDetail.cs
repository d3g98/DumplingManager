namespace DumplingManager.Data.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
        public double DeliveryQuantity { get; set; }
        public double DebitQuantity { get; set; }
        public double Price { get; set; }
        public double Total { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}