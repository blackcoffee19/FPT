using Microsoft.EntityFrameworkCore;
using TestAdminCRUD.Data;
using TestAdminCRUD.Respository;

var builder = WebApplication.CreateBuilder(args);
//Connect Database
builder.Services.AddDbContext<AdminDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("AdminCrudConnectionString")));
//add Respository to the container 
builder.Services.AddTransient<IAdminRespository, AdminRespository>();
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
