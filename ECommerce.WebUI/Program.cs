using ECommerce.Application.Abstract;
using ECommerce.Application.Abstracts;
using ECommerce.Application.Concrete;
using ECommerce.DataAccess.Abstact;
using ECommerce.DataAccess.Concerete.EFEntityFramework;
using ECommerce.DataAccess.Context;
using ECommerce.WebUI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddSession();

builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductDal,EFProductDal>();
builder.Services.AddScoped<IProductService,ProductService>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddSingleton<ICartSessionService,CartSessionService>();
builder.Services.AddScoped<ICartService,CartService>();  

#region Database registration
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<NorthWindDbContext>(opt =>
{
    opt.UseSqlServer(conn);
});
#endregion


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();
