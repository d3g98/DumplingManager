namespace DumplingManager.Application.Catalogs.Products
{
    public class ProductRequest
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double Price2 { get; set; }
        public double Price3 { get; set; }
        public double Price4 { get; set; }
        public double Price5 { get; set; }
        public string Image { get; set; }
        public string Note { get; set; }
    }
}
