using FluentValidation;
using HttpRequestAppMVC.Application.Interfaces.Requests;
using HttpRequestAppMVC.Application.Interfaces.RequestLists;
using HttpRequestAppMVC.Application.Services;
using HttpRequestAppMVC.Application.Services.RequestServices;
using HttpRequestAppMVC.Application.ViewModels.RequestLists;
using HttpRequestAppMVC.Application.ViewModels.Requests;
using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Infrastructure;
using HttpRequestAppMVC.Infrastructure.Repositories;
using HttpRequestAppMVC.Infrastructure.Repositories.Requests;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IRequestSenderRepository, RequestSenderRepository>();
builder.Services.AddTransient<IRequestSenderService, RequestSenderService>();
builder.Services.AddTransient<IRequestService, RequestService>();
builder.Services.AddTransient<IRequestRepository, RequestRepository>();
builder.Services.AddTransient<IRequestListRepository, HttpRequestListRepository>();
builder.Services.AddTransient<IRequestListService, RequestListService>();
builder.Services.AddTransient<IHeaderService, HttpHeaderService>();
builder.Services.AddTransient<IValidator<CreateRequestListVm>, CreateRequestListVmValidator>();
builder.Services.AddTransient<IValidator<CreateRequestVm>, CreateRequestVmValidator>();
builder.Services.AddTransient<IValidator<RequestVm>, EditRequestVmValidator>();
builder.Services.AddTransient<IRequestHeaderRepository, RequestHeaderRepository>();
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
    pattern: "{controller=RequestList}/{action=Index}/{id?}");

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
//TODO: clean up views
//TODO: Move to user auth 

