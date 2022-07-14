using System.Collections.Immutable;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using NorthwindLibrary;
using NorthwindLibrary.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

var databasePath = Path.Combine("..", "Northwind.db");

builder.Services.AddDbContext<NorthwindDbContext>(options => options.UseSqlite($"Data Source={databasePath}"));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// Adding Repositories
//builder.Services.AddScoped(typeof(IBaseRepository<,>), typeof(BaseRepository<,>));
//builder.Services.AddScoped(typeof(DbContext),typeof(NorthwindDbContext));

builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<IBaseRepository<Category, NorthwindDbContext>, CategoryRepository>(x => x.GetRequiredService<CategoryRepository>());
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>(x => x.GetRequiredService<CategoryRepository>());

builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<IBaseRepository<Product, NorthwindDbContext>, ProductRepository>(x => x.GetRequiredService<ProductRepository>());
builder.Services.AddScoped<IProductRepository, ProductRepository>(x => x.GetRequiredService<ProductRepository>());

builder.Services.AddScoped<OrderRepository>();
builder.Services.AddScoped<IBaseRepository<Order, NorthwindDbContext>, OrderRepository>(x => x.GetRequiredService<OrderRepository>());
builder.Services.AddScoped<IOrderRepository, OrderRepository>(x => x.GetRequiredService<OrderRepository>());

builder.Services.AddScoped<OrderDetailRepository>();
builder.Services.AddScoped<IBaseRepository<OrderDetail, NorthwindDbContext>, OrderDetailRepository>(x => x.GetRequiredService<OrderDetailRepository>());
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>(x => x.GetRequiredService<OrderDetailRepository>());

builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<IBaseRepository<Customer, NorthwindDbContext>, CustomerRepository>(x => x.GetRequiredService<CustomerRepository>());
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>(x => x.GetRequiredService<CustomerRepository>());

builder.Services.AddScoped<EmployeeRepository>();
builder.Services.AddScoped<IBaseRepository<Employee, NorthwindDbContext>, EmployeeRepository>(x => x.GetRequiredService<EmployeeRepository>());
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>(x => x.GetRequiredService<EmployeeRepository>());

builder.Services.AddScoped<ShipperRepository>();
builder.Services.AddScoped<IBaseRepository<Shipper, NorthwindDbContext>, ShipperRepository>(x => x.GetRequiredService<ShipperRepository>());
builder.Services.AddScoped<IShipperRepository, ShipperRepository>(x => x.GetRequiredService<ShipperRepository>());

builder.Services.AddScoped<SupplierRepository>();
builder.Services.AddScoped<IBaseRepository<Supplier, NorthwindDbContext>, SupplierRepository>(x => x.GetRequiredService<SupplierRepository>());
builder.Services.AddScoped<ISupplierRepository, SupplierRepository>(x => x.GetRequiredService<SupplierRepository>());


// Adding Services
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IOrderDetailService, OrderDetailService>();
builder.Services.AddScoped<ISupplierService, SupplierService>();
builder.Services.AddScoped<IShipperService, ShipperService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
