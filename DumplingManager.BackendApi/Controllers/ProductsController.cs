using DumplingManager.Application.Catalogs.Products;
using DumplingManager.Application.Commons;
using DumplingManager.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DumplingManager.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService<Guid, Product> _service;
        public ProductsController(IProductService<Guid, Product> service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult List(CustomFilterParam<Guid> param)
        {
            return Ok(_service.GetAll(param));
        }

        [HttpPost]
        public IActionResult Insert(ProductRequest param)
        {
            return Ok(_service.Insert(param));
        }

        [HttpPut]
        public IActionResult Update(ProductRequest param)
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