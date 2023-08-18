using DumplingManager.Application.Commons;
using DumplingManager.Application.Model.Catalog;
using DumplingManager.Data.Entities;

namespace DumplingManager.Application.Service.Catalog
{
    public interface ICustomerService
    {
        ApiResult<IEnumerable<Customer>> Get();
        ApiResult<IEnumerable<Customer>> GetActive();
        ApiResult<Customer> Create(CustomerCreateRequest model);
        ApiResult<Customer> Update(CustomerUpdateRequest model);
        ApiResult<bool> Delete(Guid id);
        Customer FindById(Guid id);
        bool Exists(Guid id);
    }
}