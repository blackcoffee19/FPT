using Microsoft.EntityFrameworkCore;
using ProductOnion.Data;
using ProductOnion.Repositories;

var builder = WebApplication.CreateBuilder(args);
//Add db server to container
builder.Services.AddDbContext<ProductDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("ProductDBConnectionString")));
//add Respository to the container 
builder.Services.AddTransient<IProductRepository, ProductRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
