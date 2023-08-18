using DumplingManager.Application.Commons;
using DumplingManager.Application.Model.Catalog;
using DumplingManager.Application.Service.Utils;
using DumplingManager.Data.EF;
using DumplingManager.Data.Entities;

namespace DumplingManager.Application.Service.Catalog
{
    public class ProductService : IProductService
    {
        private readonly DumplingDbContext _db;
        private readonly IFileService _fileService;
        public ProductService(DumplingDbContext db, IFileService fileService)
        {
            _db = db;
            _fileService = fileService;
        }

        public ApiResult<IEnumerable<Product>> Get()
        {
            return new OkResult<IEnumerable<Product>>(_db.Products.ToList());
        }

        public ApiResult<IEnumerable<Product>> GetActive()
        {
            return new OkResult<IEnumerable<Product>>(_db.Products.Where(x => x.Status == 30).ToList());
        }

        public ApiResult<Product> Create(ProductCreateRequest model)
        {
            try
            {
                //kiểm tra Tồn
                IQueryable<Product> query = _db.Products.Where(x => x.Code.ToLower() == model.Code.ToLower());
                if (query.Count() > 0) return new ErrorResult<Product>("Mã hàng đã tồn tại");

                query = _db.Products.Where(x => x.Name.ToLower() == model.Name.ToLower());
                if (query.Count() > 0) return new ErrorResult<Product>("Mã hàng đã tồn tại");

                Product data = new Product();
                SetData(data, model);
                _db.Products.Add(data);
                _db.SaveChanges();
                return new OkResult<Product>(data);
            }
            catch (Exception e)
            {
                return new ErrorResult<Product>($"{e.Message} : {e.StackTrace}");
            }
        }

        public ApiResult<Product> Update(ProductUpdateRequest model)
        {
            try
            {
                IQueryable<Product> query = _db.Products.Where(x => x.Code.ToLower() == model.Code.ToLower() && x.Id != model.Id);
                if (query.Count() > 0) return new ErrorResult<Product>("Mã hàng đã tồn tại");

                query = _db.Products.Where(x => x.Name.ToLower() == model.Name.ToLower() && x.Id != model.Id);
                if (query.Count() > 0) return new ErrorResult<Product>("Mặt hàng đã tồn tại");

                Product? data = _db.Find<Product>(model.Id);
                if (data == null) return new ErrorResult<Product>("Mặt hàng không tồn tại");
                SetData(data, model);
                _db.Products.Entry(data);
                _db.SaveChanges();
                return new OkResult<Product>(data);
            }
            catch (Exception e)
            {
                return new ErrorResult<Product>($"{e.Message} : {e.StackTrace}");
            }
        }

        private void SetData(Product data, ProductCreateRequest model)
        {
            data.Code = model.Code.Trim();
            data.Name = model.Name.Trim();
            data.Price = model.Price;
            data.Price2 = model.Price2;
            data.Price3 = model.Price3;
            data.Price4 = model.Price4;
            data.Price5 = model.Price5;
            data.Image = _fileService.Upload(Defaults.FolderImageProduct, model.Image);
            if (model.Note != null) data.Note = model.Note.Trim();
            else data.Note = model.Note;
        }

        public ApiResult<bool> Delete(Guid id)
        {
            try
            {
                Product? data = _db.Find<Product>(id);
                if (data == null) return new ErrorResult<bool>("Mặt hàng không tồn tại");
                _db.Products.Remove(data);
                _db.SaveChanges();
                return new OkResult<bool>(true);
            }
            catch (Exception e)
            {
                return new ErrorResult<bool>($"{e.Message} : {e.StackTrace}");
            }
        }

        public bool Exists(Guid id)
        {
            return FindById(id) != null;
        }

        public Product FindById(Guid id)
        {
            return _db.Find<Product>(id);
        }
    }
}