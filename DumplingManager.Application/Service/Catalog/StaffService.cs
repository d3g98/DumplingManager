using DumplingManager.Application.Commons;
using DumplingManager.Application.Model.Catalog;
using DumplingManager.Data.EF;
using DumplingManager.Data.Entities;

namespace DumplingManager.Application.Service.Catalog
{
    public class StaffService : IStaffService
    {
        private readonly DumplingDbContext _db;
        public StaffService(DumplingDbContext db)
        {
            _db = db;
        }

        public ApiResult<IEnumerable<Staff>> Get()
        {
            return new OkResult<IEnumerable<Staff>>(_db.Staffs.ToList());
        }

        public ApiResult<IEnumerable<Staff>> GetActive()
        {
            return new OkResult<IEnumerable<Staff>>(_db.Staffs.Where(x => x.Status == 30).ToList());
        }

        public ApiResult<Staff> Create(StaffCreateRequest model)
        {
            try
            {
                IQueryable<Staff> query = _db.Staffs.Where(x => x.Name.ToLower() == model.Name.ToLower());
                if (query.Count() > 0) return new ErrorResult<Staff>("Nhân viên đã tồn tại");

                query = _db.Staffs.Where(x => x.Phone.ToLower() == model.Phone.ToLower());
                if (query.Count() > 0) return new ErrorResult<Staff>("Số điện thoại đã tồn tại");

                Staff data = new Staff();
                SetData(data, model);
                _db.Staffs.Add(data);
                _db.SaveChanges();
                return new OkResult<Staff>(data);
            }
            catch (Exception e)
            {
                return new ErrorResult<Staff>($"{e.Message} : {e.StackTrace}");
            }
        }

        public ApiResult<Staff> Update(StaffUpdateRequest model)
        {
            try
            {
                IQueryable<Staff> query = _db.Staffs.Where(x => x.Name.ToLower() == model.Name.ToLower());
                if (query.Count() > 0) return new ErrorResult<Staff>("Nhân viên đã tồn tại");

                query = _db.Staffs.Where(x => x.Phone.ToLower() == model.Phone.ToLower());
                if (query.Count() > 0) return new ErrorResult<Staff>("Số điện thoại đã tồn tại");

                Staff? data = _db.Find<Staff>(model.Id);
                if (data == null) return new ErrorResult<Staff>("Nhân viên không tồn tại");
                SetData(data, model);
                _db.Staffs.Entry(data);
                _db.SaveChanges();
                return new OkResult<Staff>(data);
            }
            catch (Exception e)
            {
                return new ErrorResult<Staff>($"{e.Message} : {e.StackTrace}");
            }
        }

        private void SetData(Staff data, StaffCreateRequest model)
        {
            data.Name = model.Name;
            data.Phone = model.Phone;
            data.Email = model.Email;
            data.Address = model.Address;
            if (model.DiscountWithQuantity > 0)
            {
                data.DiscountOne = model.DiscountOne;
                data.DiscountPercent = 0;
            }
            else
            {
                data.DiscountOne = 0;
                data.DiscountPercent = model.DiscountPercent;
            }
            if (model.Note != null) data.Note = model.Note.Trim();
            else data.Note = model.Note;
        }

        public ApiResult<bool> Delete(Guid id)
        {
            try
            {
                Staff? searchData = _db.Find<Staff>(id);
                if (searchData == null) return new ErrorResult<bool>("Nhân viên không tồn tại");
                _db.Staffs.Remove(searchData);
                _db.SaveChanges();
                return new OkResult<bool>(true);
            }
            catch (Exception e)
            {
                return new ErrorResult<bool>($"{e.Message} : {e.StackTrace}");
            }
        }

        public Staff FindById(Guid id)
        {
            return _db.Find<Staff>(id);
        }

        public bool Exists(Guid id)
        {
            return FindById(id) != null;
        }
    }
}