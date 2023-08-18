using DumplingManager.Application.Model.Catalog;
using DumplingManager.Application.Service.Catalog;
using Microsoft.AspNetCore.Mvc;

namespace DumplingManager.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        private readonly IStaffService _service;
        public StaffsController(IStaffService service)
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
        public IActionResult Create(StaffCreateRequest param)
        {
            return Ok(_service.Create(param));
        }

        [HttpPut]
        public IActionResult Update(StaffUpdateRequest param)
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