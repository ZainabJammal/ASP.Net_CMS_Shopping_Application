using CMS_Shopping_Cart.Infrastructure;
using CMS_Shopping_Cart.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMemoryCache();
builder.Services.AddSession();
//    (options =>
//{
//    //options.IdleTimeout = TimeSpan.FromSeconds(2);
//    //options.IdleTimeout = TimeSpan.FromDays(2);
//});
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CmsShoppingCartContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("CmsShoppingCartContext")));
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
})
        .AddEntityFrameworkStores<CmsShoppingCartContext>()
        .AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        SeedData.Initialize(services);
    }
    catch (Exception) { throw; }
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    "pages",
    "{slug?}",
    defaults: new {controller = "Pages" , action = "Page"}
   );

//app.MapControllerRoute(
//        "products",
//         pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
//        );

app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
          );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
   );

app.Run();
