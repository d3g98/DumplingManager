namespace DumplingManager.Application.Model.Catalog
{
    public class ProductUpdateRequest : ProductCreateRequest
    {
        public Guid Id { get; set; }
    }
}
