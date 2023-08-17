namespace DumplingManager.Application.Catalogs.TypePrices
{
    public interface ITypePriceService
    {
        IEnumerable<TypePrice> Get();
    }

    public class TypePrice
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}