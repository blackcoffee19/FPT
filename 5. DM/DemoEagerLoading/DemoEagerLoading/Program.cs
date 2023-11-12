using DemoEagerLoading.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<EagerLoadingDbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("EagerLoadingConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
