namespace DumplingManager.Application.Catalogs.TypePrices
{
    public class TypePriceService : ITypePriceService
    {
        public IEnumerable<TypePrice> Get()
        {
            return new[]
            {
                new TypePrice() { Id = 0, Name = "Giá bán" },
                new TypePrice() { Id = 1, Name = "Giá bán 2" },
                new TypePrice() { Id = 2, Name = "Giá bán 3" },
                new TypePrice() { Id = 3, Name = "Giá bán 4" },
                new TypePrice() { Id = 4, Name = "Giá bán 5" }
            };
        }
    }
}