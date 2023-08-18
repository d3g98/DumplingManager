using DumplingManager.Application.Model.Catalog;
using DumplingManager.Application.Service.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace DumplingManager.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _service;
        public CustomersController(ICustomerService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_service.Get());
        }

        [HttpGet("active")]
        public IActionResult ListActive()
        {
            return Ok(_service.GetActive());
        }

        [HttpPost]
        public IActionResult Create(CustomerCreateRequest param)
        {
            return Ok(_service.Create(param));
        }

        [HttpPut]
        public IActionResult Update(CustomerUpdateRequest param)
        {
            return Ok(_service.Update(param));
        }

        [HttpDelete]
        public IActionResult Delete(Guid id)
        {
            return Ok(_service.Delete(id));
        }

        [HttpGet("{id}")]
        public IActionResult FindById(Guid id)
        {
            return Ok(_service.FindById(id));
        }
    }
}