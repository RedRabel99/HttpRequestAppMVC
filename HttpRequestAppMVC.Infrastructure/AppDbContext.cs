using HttpRequestAppMVC.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Infrastructure;

public class AppDbContext : IdentityDbContext
{   
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<HttpRequestList> HttpRequestLists { get; set; }
    public DbSet<HttpRequest> HttpRequests { get; set; }
    public DbSet<RequestHeaderValue> RequestHeaderValues { get; set; }
    public DbSet<HttpResponse> HttpResponses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<HttpRequestList>()
            .Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Entity<HttpRequest>()
            .Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Entity<RequestHeaderValue>()
            .Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Entity<HttpResponse>()
            .Property(r => r.Id).ValueGeneratedOnAdd();

        builder.Entity<HttpRequestList>()
            .HasMany(r => r.HttpRequests)
            .WithOne(r => r.RequestList)
            .HasForeignKey(r => r.RequestListId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<HttpRequest>()
            .HasMany(r => r.HeaderValues)
            .WithOne(r => r.HttpRequest)
            .HasForeignKey(r => r.HttpRequestId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<HttpRequest>()
            .HasMany(r => r.ResponseHistory)
            .WithOne(r => r.HttpRequest)
            .HasForeignKey(r => r.HttpRequestId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}