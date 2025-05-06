using HttpRequestAppMVC.Application.Interfaces;
using HttpRequestAppMVC.Application.Services;
using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Infrastructure;
using HttpRequestAppMVC.Infrastructure.Repositories;
using HttpRequestAppMVC.Infrastructure.Repositories.HttpRequsts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IRequestSenderRepository, RequestSenderRepository>();
builder.Services.AddTransient<IRequestSenderService, RequestSenderService>();
builder.Services.AddTransient<IHttpRequestService, HttpRequestService>();
builder.Services.AddTransient<IHttpRequestRepository, HttpRequestRepository>();
builder.Services.AddTransient<IHttpRequestListRepository, HttpRequestListRepository>();
builder.Services.AddTransient<IHttpRequestListService, HttpRequestListService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


var app = builder.Build();

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
