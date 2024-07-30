using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Configurations;
using DataAccess.Context;
using DataAccess.DependencyInjection;
using Entities.Identity;
using ErhasTestCase.Middleware;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
ServiceRegistration.AddServices(builder.Services);
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, EfCategoryRepository>();
builder.Services.AddScoped<IBasketService, BasketService>();
builder.Services.AddScoped<IBasketRepository, EfBasketRepository>();
builder.Services.AddScoped<IBasketItemRepository, EfBasketItemRepository>();
builder.Services.AddIdentity<AppUser, AppRole>()
         .AddEntityFrameworkStores<AppDbContext>()
         .AddDefaultTokenProviders();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
