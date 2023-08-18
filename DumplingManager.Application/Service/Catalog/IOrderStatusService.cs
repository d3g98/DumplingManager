namespace DumplingManager.Application.Service.Catalog
{
    public interface IOrderStatusService
    {
        IEnumerable<OrderStatus> Get();
    }

    public class OrderStatus
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}