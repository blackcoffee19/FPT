using Microsoft.EntityFrameworkCore;
using TestReactApi.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AccountDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AccountDBConnect")));

builder.Services.AddControllers();
builder.Services.AddDistributedMemoryCache();
//Adding the IHttpContextAccessor servive to the Dependency Injection IOC Container
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();
app.UseSession();
app.MapControllers();

app.Run();
