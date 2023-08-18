namespace DumplingManager.Application.Model.Transactions
{
    public class OrderCreateRequest
    {
        public string Date { get; set; }
        public string Name { get; set; }
        public double Total { get; set; }
        public Guid StaffId { get; set; }
        public Guid CustomerId { get; set; }

        public int StaffDiscountWithQuantity { get; set; }
        public double StaffDiscountPercent { get; set; }
        public double StaffDiscount { get; set; }
        public string Note { get; set; }

        public IEnumerable<OrderDetailModel> details { set; get; }
    }
}