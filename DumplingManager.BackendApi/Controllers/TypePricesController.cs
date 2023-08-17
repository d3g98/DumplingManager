using DumplingManager.Application.Catalogs.TypePrices;
using Microsoft.AspNetCore.Mvc;

namespace DumplingManager.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypePricesController : ControllerBase
    {
        private readonly ITypePriceService _service;
        public TypePricesController(ITypePriceService service)
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
