using Microsoft.AspNetCore.Http;

namespace DumplingManager.Application.Model.Catalog
{
    public class ProductCreateRequest
    {
        public Guid UserId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Price2 { get; set; }
        public double Price3 { get; set; }
        public double Price4 { get; set; }
        public double Price5 { get; set; }
        public IFormFile Image { get; set; }
        public string Note { get; set; }
    }
}
