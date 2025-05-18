using FluentValidation;
using HttpRequestAppMVC.Application.Interfaces.HttpRequest;
using HttpRequestAppMVC.Application.Interfaces.HttpRequestList;
using HttpRequestAppMVC.Application.Services;
using HttpRequestAppMVC.Application.Services.HttpRequestServices;
using HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;
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
builder.Services.AddTransient<IHttpHeaderService, HttpHeaderService>();
builder.Services.AddTransient<IValidator<CreateHttpRequestListVm>, CreateHttpRequestListVmValidator>();

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


//TODO: Implement missing crud operations for httprequest
//TODO: CREATE Builder for http request from db entry
//TODO: update httprequestsender to use httpclient factory
//TODO: create http response models
//TODO: repo and service for http response 
//TODO: design views and controllers for response
//TODO: automate saving response
//TODO: Use fluid validation
//TODO: CREATE TESTS FOR SERVICES
//TODO: Move to user auth 

