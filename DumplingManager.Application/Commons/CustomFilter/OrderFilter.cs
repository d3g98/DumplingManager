namespace DumplingManager.Application.Commons.CustomFilter
{
    public class OrderFilter : TransactionFilter
    {
        public Guid StaffId { get; set; }
        public Guid CustomerId { get; set; }
    }
}