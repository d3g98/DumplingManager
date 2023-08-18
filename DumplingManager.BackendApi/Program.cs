using DumplingManager.Application.Service.Catalog;
using DumplingManager.Application.Service.Orders;
using DumplingManager.Application.Service.Utils;
using DumplingManager.Data.EF;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddDbContext<DumplingDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DumplingDb"));
});
builder.Services.AddTransient<IFileService, FileService>();
builder.Services.AddTransient<IOrderStatusService, OrderStatusService>();
builder.Services.AddTransient<ITypePriceService, TypePriceService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IStaffService, StaffService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
