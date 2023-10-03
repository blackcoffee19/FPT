using Ex1.Data;
using Ex1.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
//Add Db SqlServer
builder.Services.AddDbContext<NewsDbContext>(o=>o.UseSqlServer(builder.Configuration.GetConnectionString("NewDBConnectionString")));

// Add AutoMapper to the container
builder.Services.AddAutoMapper(typeof(NewsDbContext).Assembly);
//Add Repository
builder.Services.AddScoped<AdminRepository>();
builder.Services.AddScoped<NewsRepository>();
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
