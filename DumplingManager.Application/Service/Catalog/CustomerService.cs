using DumplingManager.Application.Commons;
using DumplingManager.Application.Model.Catalog;
using DumplingManager.Data.EF;
using DumplingManager.Data.Entities;

namespace DumplingManager.Application.Service.Catalog
{
    public class CustomerService : ICustomerService
    {
        private readonly DumplingDbContext _db;
        public CustomerService(DumplingDbContext db)
        {
            _db = db;
        }

        public ApiResult<IEnumerable<Customer>> Get()
        {
            return new OkResult<IEnumerable<Customer>>(_db.Customers.ToList());
        }

        public ApiResult<IEnumerable<Customer>> GetActive()
        {
            return new OkResult<IEnumerable<Customer>>(_db.Customers.Where(x => x.Status == 30).ToList());
        }

        public ApiResult<Customer> Create(CustomerCreateRequest model)
        {
            try
            {
                IQueryable<Customer> query = _db.Customers.Where(x => x.Name.ToLower() == model.Name.ToLower());
                if (query.Count() > 0) return new ErrorResult<Customer>("Tên khách hàng đã tồn tại");

                query = _db.Customers.Where(x => x.Phone.ToLower() == model.Phone.ToLower());
                if (query.Count() > 0) return new ErrorResult<Customer>("Số điện thoại đã tồn tại");

                Customer data = new Customer();
                SetData(data, model);
                _db.Customers.Add(data);
                _db.SaveChanges();
                return new OkResult<Customer>(data);
            }
            catch (Exception e)
            {
                return new ErrorResult<Customer>($"{e.Message} : {e.StackTrace}");
            }
        }

        public ApiResult<Customer> Update(CustomerUpdateRequest model)
        {
            try
            {
                IQueryable<Customer> query = _db.Customers.Where(x => x.Name.ToLower() == model.Name.ToLower());
                if (query.Count() > 0) return new ErrorResult<Customer>("Tên khách hàng đã tồn tại");

                query = _db.Customers.Where(x => x.Phone.ToLower() == model.Phone.ToLower());
                if (query.Count() > 0) return new ErrorResult<Customer>("Số điện thoại đã tồn tại");

                Customer? data = _db.Find<Customer>(model.Id);
                if (data == null) return new ErrorResult<Customer>("Khách hàng không tồn tại");
                SetData(data, model);
                _db.Customers.Entry(data);
                _db.SaveChanges();
                return new OkResult<Customer>(data);
            }
            catch (Exception e)
            {
                return new ErrorResult<Customer>($"{e.Message} : {e.StackTrace}");
            }
        }

        private void SetData(Customer data, CustomerCreateRequest model)
        {
            data.Name = model.Name;
            data.Phone = model.Phone;
            data.Email = model.Email;
            data.Address = model.Address;
            data.TypePriceId = model.TypePriceId;
            data.UseCabinet = model.UseCabinet;
            if (model.Note != null) data.Note = model.Note.Trim();
            else data.Note = model.Note;
        }

        public ApiResult<bool> Delete(Guid id)
        {
            try
            {
                Customer? searchData = _db.Find<Customer>(id);
                if (searchData == null) return new ErrorResult<bool>("Khách hàng không tồn tại");
                _db.Customers.Remove(searchData);
                _db.SaveChanges();
                return new OkResult<bool>(true);
            }
            catch (Exception e)
            {
                return new ErrorResult<bool>($"{e.Message} : {e.StackTrace}");
            }
        }

        public Customer FindById(Guid id)
        {
            return _db.Find<Customer>(id);
        }

        public bool Exists(Guid id)
        {
            return FindById(id) != null;
        }
    }
}