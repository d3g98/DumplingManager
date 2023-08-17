using DumplingManager.Application.Catalogs.OrderStatus;
using Microsoft.AspNetCore.Mvc;

namespace DumplingManager.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatussController : ControllerBase
    {
        private readonly IOrderStatusService _service;
        public OrderStatussController(IOrderStatusService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_service.Get());
        }
    }
}
