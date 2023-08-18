namespace DumplingManager.Application.Service.Catalog
{
    public class OrderStatusService : IOrderStatusService
    {
        public IEnumerable<OrderStatus> Get()
        {
            return new[]
            {
                new OrderStatus() { Id = 0, Name = "Chưa tiếp nhận" },
                new OrderStatus() { Id = 1, Name = "Đã tiếp nhận" },
                new OrderStatus() { Id = 2, Name = "Hoàn tất đóng gói" },
                new OrderStatus() { Id = 3, Name = "Đang giao hàng" },
                new OrderStatus() { Id = 4, Name = "Hoàn tất" }
            };
        }
    }
}