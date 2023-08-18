namespace DumplingManager.Application.Model.Transactions
{
    public class OrderDetailModel
    {
        public Guid ProductId { get; set; }
        public double Quantity { get; set; }
        public double DeliveryQuantity { get; set; }
        public double DebitQuantity { get; set; }
        public double Price { get; set; }
    }
}
