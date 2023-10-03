using Ex2.Data;
using Ex2.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSession(cfg =>
{
    cfg.Cookie.Name = "aptech";
    cfg.IdleTimeout = new TimeSpan(0, 60, 0);
});
builder.Services.AddDbContext<BankContext>(o=> o.UseSqlServer(builder.Configuration.GetConnectionString("ExerciseConnectionString")));
builder.Services.AddScoped<PeopleRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
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
