using DumplingManager.Application.Commons;
using DumplingManager.Application.Model.Catalog;
using DumplingManager.Data.Entities;

namespace DumplingManager.Application.Service.Catalog
{
    public interface IStaffService
    {
        ApiResult<IEnumerable<Staff>> Get();
        ApiResult<IEnumerable<Staff>> GetActive();
        ApiResult<Staff> Create(StaffCreateRequest model);
        ApiResult<Staff> Update(StaffUpdateRequest model);
        ApiResult<bool> Delete(Guid id);
        Staff FindById(Guid id);
        bool Exists(Guid id);
    }
}