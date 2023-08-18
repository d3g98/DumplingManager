using DumplingManager.Application.Commons;
using DumplingManager.Application.Utils;
using DumplingManager.Data.EF;
using DumplingManager.Data.Entities;

namespace DumplingManager.Application.Catalogs.Products
{
    public class ProductService : IProductService<Guid, Product>
    {
        private readonly DumplingDbContext _db;
        public ProductService(DumplingDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Product> GetAll(CustomFilterParam<Guid> param)
        {
            IQueryable<Product> products = _db.Products.Where(x=>x.Status == 30);
            if (param != null)
            {
                if (param.search != null && param.search.Length > 0) products = products.Where(x=>x.Name.ToLower().Contains(param.search.ToLower()));
                products = products.Take(param.pageSize??0);
                products = products.Skip(param.pageSize??0);
            }
            return products.ToList();
        }

        public ApiResult<Product> Insert(ProductRequest model)
        {
            try
            {
                if (isExists(model)) return new ErrorResult<Product>("Mã hàng, tên hàng đã tồn tại");

                Product newData = new Product();
                newData.CreatedData(model.UserId);
                newData.Code = model.Code;
                newData.Name = model.Name;
                newData.Price = model.Price;
                newData.Price2 = model.Price2;
                newData.Price3 = model.Price3;
                newData.Price4 = model.Price4;
                newData.Price5 = model.Price5;
                newData.Image = model.Image;
                _db.Products.Add(newData);
                _db.SaveChanges();
                return new OkResult<Product>(newData);
            }
            catch (Exception e)
            {
                return new ErrorResult<Product>(e.Message);
            }
        }

        public ApiResult<Product> Update(ProductRequest model)
        {
            try
            {
                if (isExists(model)) return new ErrorResult<Product>("Mã hàng, tên hàng đã tồn tại");

                Product? updateData = _db.Find<Product>(model.Id);
                if (updateData == null) return new ErrorResult<Product>("Mặt hàng không tồn tại");
                updateData.ModifiedData(model.UserId);
                updateData.Code = model.Code;
                updateData.Name = model.Name;
                updateData.Price = model.Price;
                updateData.Price2 = model.Price2;
                updateData.Price3 = model.Price3;
                updateData.Price4 = model.Price4;
                updateData.Price5 = model.Price5;
                updateData.Image = model.Image;
                _db.Products.Entry(updateData);
                _db.SaveChanges();
                return new OkResult<Product>(updateData);
            }
            catch (Exception e)
            {
                return new ErrorResult<Product>(e.Message);
            }
        }

        private bool isExists(ProductRequest model)
        {
            IQueryable<Product> query = _db.Products.Where(x=>x.Code.ToLower() == model.Code.ToLower() || x.Name.ToLower() == model.Name.ToLower());
            if (model.Id != null && model.Id.ToString().Length > 0) query = query.Where(x => x.Id != model.Id);
            return query.ToList().Count > 0;
        }

        public ApiResult<bool> Delete(Guid id)
        {
            try
            {
                Product? searchData = _db.Find<Product>(id);
                if (searchData == null) return new ErrorResult<bool>("Mặt hàng không tồn tại");
                _db.Products.Remove(searchData);
                _db.SaveChanges();
                return new OkResult<bool>(true);
            }
            catch (Exception e)
            {
                return new ErrorResult<bool>(e.Message);
            }
        }

        public ApiResult<Product> FindById(Guid id)
        {
            try
            {
                Product? searchData = _db.Find<Product>(id);
                if (searchData == null) return new ErrorResult<Product>("Mặt hàng không tồn tại");
                return new OkResult<Product>(searchData);
            }
            catch (Exception e)
            {
                return new ErrorResult<Product>(e.Message);
            }
        }
    }
}