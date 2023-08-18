namespace DumplingManager.Data.Entities
{
    public class Order : BaseEntity
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public double Total { get; set; }
        public double TotalQuantity { get; set; }
        public Guid StaffId { get; set; }
        public Guid CustomerId { get; set; }

        public int StaffDiscountWithQuantity { get; set; }
        public double StaffDiscountPercent { get; set; }
        public double StaffDiscountOne { get; set; }
        public double StaffDiscount { get; set; }

        public Staff Staff { get; set; }
        public Customer Customer { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}