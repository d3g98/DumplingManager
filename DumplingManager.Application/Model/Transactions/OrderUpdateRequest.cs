namespace DumplingManager.Application.Model.Transactions
{
    public class OrderUpdateRequest : OrderCreateRequest
    {
        public Guid Id { get; set; }
    }
}
