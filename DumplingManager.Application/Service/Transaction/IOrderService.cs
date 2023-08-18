using DumplingManager.Application.Commons;
using DumplingManager.Application.Commons.CustomFilter;
using DumplingManager.Application.Model.Transactions;
using DumplingManager.Data.Entities;

namespace DumplingManager.Application.Service.Orders
{
    public interface IOrderService
    {
        public string GenName();
        public PagedResult<Order> Get(OrderFilter filter);
        public ApiResult<Order> Create(OrderCreateRequest model);
        public ApiResult<Order> Update(OrderUpdateRequest model);
    }
}
