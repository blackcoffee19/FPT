using DemoIdentity.Data;
using DemoIdentity.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
/*builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();*/

/*builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();*/
/*builder.Services.AddDefaultIdentity<AppUser>(op => op.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<ApplicationDbContext>();
*/
builder.Services.AddIdentity<AppUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
builder.Services.AddAuthentication().AddGoogle(o =>
{
    var ggSection = builder.Configuration.GetSection("Authentication:Google");
    o.ClientId = ggSection["ClientId"];
    o.ClientSecret = ggSection["ClientSerect"];
    o.CallbackPath = "/call-back";
});
builder.Services.ConfigureApplicationCookie(o =>
{
    o.AccessDeniedPath = "/Identity/Account/AccessDenied";
    o.LoginPath = "/Identity/Account/Login";
    o.LogoutPath = "/Identity/Account/Logout";
});
builder.Services.Configure<IdentityOptions>(op => {
    //Cau hinh Password
    op.Password.RequireDigit = false;
    op.Password.RequireLowercase = false;
    op.Password.RequireNonAlphanumeric = false;
    op.Password.RequireUppercase = false;
    op.Password.RequiredLength = 3;
    op.Password.RequiredUniqueChars = 1;
    //Cau hinh Lock User
    op.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    op.Lockout.AllowedForNewUsers = true;
    //Cau hinh cho user
    op.User.AllowedUserNameCharacters = "asdfghjklqwertyuiopzxcvbnmASDFGHJKLQWERTYUIOPZXCVBNM0123456789._@+-";
    op.User.RequireUniqueEmail = true;
    //Cau hinh dang nhap
    op.SignIn.RequireConfirmedEmail = false;
    op.SignIn.RequireConfirmedPhoneNumber = false;

});

builder.Services.AddOptions();
var mailSetting = builder.Configuration.GetSection("MailSettings");
builder.Services.Configure<MailSettings>(mailSetting);
builder.Services.AddTransient<IEmailSender, SendMailService>();
builder.Services.AddAuthorization(o =>
{
    o.AddPolicy("CanView", policy =>
    {
        policy.RequireRole("admin");
    });
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
