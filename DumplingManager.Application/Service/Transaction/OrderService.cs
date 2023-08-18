using DumplingManager.Application.Commons;
using DumplingManager.Application.Commons.CustomFilter;
using DumplingManager.Application.Model.Transactions;
using DumplingManager.Application.Service.Catalog;
using DumplingManager.Data.EF;
using DumplingManager.Data.Entities;

namespace DumplingManager.Application.Service.Orders
{
    public class OrderService : IOrderService
    {
        private readonly DumplingDbContext _db;
        private readonly ICustomerService _customerService;
        private readonly IStaffService _staffService;
        private readonly IProductService _productService;
        public OrderService(DumplingDbContext db, ICustomerService customerService, IStaffService staffService, IProductService productService)
        {
            _db = db;
            _customerService = customerService;
            _staffService = staffService;
            _productService = productService;
        }

        public PagedResult<Order> Get(OrderFilter filter)
        {
            IQueryable<Order> query = _db.Orders.Where(x => x.Date >= filter.GetFromDate() && x.Date <= filter.GetToDate());
            if (filter.CustomerId != Guid.Empty) query = query.Where(x => x.CustomerId == filter.CustomerId);
            if (filter.StaffId != Guid.Empty) query = query.Where(x => x.StaffId == filter.StaffId);
            int totalItems = query.Count();
            query = query.Take(filter.PageSize).Skip((filter.Page - 1) * filter.PageSize);
            return new PagedResult<Order>(totalItems, filter, query.ToList());
        }

        public ApiResult<Order> Create(OrderCreateRequest model)
        {
            try
            {
                string error;
                Customer customer;
                Staff staff;

                //Kiểm tra tham số
                CheckInfo(model, out customer, out staff, out error);
                if (error.Length > 0) return new ErrorResult<Order>(error);

                //model to entity
                Order data = new Order();
                SetData(data, model, customer, staff, out error);
                if (error.Length > 0)
                {
                    return new ErrorResult<Order>(error);
                }
                _db.Orders.Add(data);
                _db.SaveChanges();
                return new OkResult<Order>(data);
            }
            catch (Exception e)
            {
                return new ErrorResult<Order>($"{e.Message} : {e.StackTrace}");
            }
        }

        public ApiResult<Order> Update(OrderUpdateRequest model)
        {
            try
            {
                string error;
                Customer customer;
                Staff staff;
                
                //Kiểm tra tham số
                CheckInfo(model, out customer, out staff, out error);
                if (error.Length > 0) return new ErrorResult<Order>(error);

                //model to entity
                Order data = new Order();
                SetData(data, model, customer, staff, out error);
                if (error.Length > 0) return new ErrorResult<Order>(error);
                _db.Orders.Add(data);
                _db.SaveChanges();
                return new OkResult<Order>(data);
            }
            catch (Exception e)
            {
                return new ErrorResult<Order>($"{e.Message} : {e.StackTrace}");
            }
        }

        private void CheckInfo(OrderCreateRequest model, out Customer customer, out Staff staff, out string error)
        {
            error = "";
            customer = _customerService.FindById(model.CustomerId);
            staff = _staffService.FindById(model.StaffId);

            if (customer == null)
            {
                error = "Khách hàng không tồn tại";
                return;
            }
            if (staff == null)
            {
                error = "Nhân viên không tồn tại";
                return;
            }
        }

        private void SetData(Order data, OrderCreateRequest model, Customer customer, Staff staff, out string error)
        {
            error = "";
            if (!(model is OrderUpdateRequest))
            {
                data.Date = DateTime.Now;
                data.Name = GenName();
            }
            data.CustomerId = model.CustomerId;
            data.StaffId = model.StaffId;

            double totalBill = 0, totalQuantity = 0;
            //details
            foreach (var item in model.details)
            {
                Product product = _productService.FindById(item.ProductId);
                if (product == null)
                {
                    error = $"Mặt hàng có mã: {item.ProductId} không tồn tại trong hệ thống";
                    break;
                }

                OrderDetail ctRow = new OrderDetail();
                ctRow.ProductId = item.ProductId;
                ctRow.Quantity = item.Quantity;
                ctRow.DeliveryQuantity = 0;
                ctRow.DebitQuantity = 0;
                ctRow.Price = GetPriceWithCustomer(product, customer);
                ctRow.Total = ctRow.Quantity * ctRow.Price;
                totalQuantity += ctRow.Quantity;
                totalBill += ctRow.Total;
            }

            data.TotalQuantity = totalQuantity;
            data.Total = totalBill;
            Calculation(data, staff);
        }

        private void Calculation(Order data, Staff staff)
        {
            if (staff.DiscountWithQuantity > 0)
            {
                data.StaffDiscountWithQuantity = 30;
                data.StaffDiscountOne = staff.DiscountOne;
                data.StaffDiscountPercent = 0;
            }
            else
            {
                data.StaffDiscountWithQuantity = 0;
                data.StaffDiscountPercent = staff.DiscountPercent;
                data.StaffDiscountOne = 0;
            }
            data.StaffDiscount = data.TotalQuantity * data.StaffDiscountOne + data.Total * data.StaffDiscountPercent / 100;
        }

        private double GetPriceWithCustomer(Product product, Customer customer)
        {
            if (customer.TypePriceId == 1) return product.Price2;
            else if (customer.TypePriceId == 2) return product.Price3;
            else if (customer.TypePriceId == 3) return product.Price4;
            else if (customer.TypePriceId == 4) return product.Price5;
            return product.Price;
        }

        public string GenName()
        {
            //HD(yy)(******)
            int length = 10;
            string start = $"HD{DateTime.Now.ToString("yy")}";
            IQueryable<Order> query = _db.Orders.Where(x => x.Name.StartsWith(start));

            int count = 0;
            string? name = query.Max(x => x.Name);
            if (!string.IsNullOrEmpty(name))
            {
                count = Convert.ToInt32(name.Replace(start, ""));
            }
            count++;

            string tmp = count.ToString();
            while ((start + tmp).Length < length)
            {
                tmp = "0" + tmp;
            }
            return start + tmp;
        }
    }
}
