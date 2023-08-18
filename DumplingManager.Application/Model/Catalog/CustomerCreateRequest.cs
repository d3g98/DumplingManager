using DumplingManager.Data.Entities;

namespace DumplingManager.Application.Model.Catalog
{
    public class CustomerCreateRequest
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int TypePriceId { get; set; }
        public int UseCabinet { get; set; }
        public string Note { get; set; }
    }
}