using DumplingManager.Application.Commons;
using DumplingManager.Data.Entities;

namespace DumplingManager.Application.Catalogs.Products
{
    public interface IProductService<Key, T>
    {
        IEnumerable<Product> GetAll(CustomFilterParam<Guid> param);
        ApiResult<Product> Insert(ProductRequest model);
        ApiResult<Product> Update(ProductRequest model);
        ApiResult<bool> Delete(Guid id);
        ApiResult<Product> FindById(Guid id);
    }
}