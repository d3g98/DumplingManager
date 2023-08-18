using DumplingManager.Application.Commons;
using DumplingManager.Application.Model.Catalog;
using DumplingManager.Data.Entities;

namespace DumplingManager.Application.Service.Catalog
{
    public interface IProductService
    {
        ApiResult<IEnumerable<Product>> Get();
        ApiResult<IEnumerable<Product>> GetActive();
        ApiResult<Product> Create(ProductCreateRequest model);
        ApiResult<Product> Update(ProductUpdateRequest model);
        ApiResult<bool> Delete(Guid id);
        Product FindById(Guid id);
        bool Exists(Guid id);
    }
}