using DumplingManager.Application.Commons.CustomFilter;
using DumplingManager.Application.Model.Transactions;
using DumplingManager.Application.Service.Orders;
using Microsoft.AspNetCore.Mvc;

namespace DumplingManager.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _service;
        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Get([FromQuery]OrderFilter filter)
        {
            return Ok(_service.Get(filter));
        }

        [HttpPost]
        public IActionResult Create(OrderCreateRequest param)
        {
            return Ok(_service.Create(param));
        }
    }
}
