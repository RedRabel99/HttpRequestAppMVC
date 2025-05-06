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
    public DbSet<HttpRequestHeader> HttpRequestHeaders { get; set; }
    public DbSet<HttpHeader> HttpHeaders { get; set; }
    public DbSet<HttpHeaderValue> HttpHeaderValues { get; set; }
    public DbSet<HttpResponse> HttpResponses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<HttpRequestList>()
            .Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Entity<HttpRequest>()
            .Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Entity<HttpRequestHeader>()
            .Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Entity<HttpResponse>()
            .Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Entity<HttpHeaderValue>()
            .Property(h => h.Id).ValueGeneratedOnAdd();
        builder.Entity<HttpHeader>()
            .Property(h => h.Id).ValueGeneratedOnAdd();

        builder.Entity<HttpRequestList>()
            .HasMany(r => r.HttpRequests)
            .WithOne(r => r.RequestList)
            .HasForeignKey(r => r.RequestListId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<HttpRequest>()
            .HasMany(r => r.HttpRequestHeaders)
            .WithOne(r => r.HttpRequest)
            .HasForeignKey(r => r.HttpRequestId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<HttpRequest>()
            .HasMany(r => r.ResponseHistory)
            .WithOne(r => r.HttpRequest)
            .HasForeignKey(r => r.HttpRequestId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<HttpRequestHeader>()
            .HasOne(h => h.HttpHeader)
            .WithMany(h => h.HttpRequestHeaders)
            .HasForeignKey(h => h.HttpHeaderId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HttpRequestHeader>()
            .HasOne(h => h.HttpHeaderValue)
            .WithMany(h => h.HttpRequestHeaders)
            .HasForeignKey(h => h.HttpHeaderValueId)
            .OnDelete(DeleteBehavior.NoAction);
        var seedTime = new DateTime(2025, 1, 1,0,0,0, DateTimeKind.Utc);
        builder.Entity<HttpHeader>().HasData(
            //Generating deterministic Guid to prevent insertion every time onModelCreating is called.
            new HttpHeader {Id = GuidHelper.GenerateDeterministicGuid("Content-Type"),Name = "Content-Type", IsCommon=true, CreatedAt=seedTime, UpdatedAt=seedTime},
            new HttpHeader {Id = GuidHelper.GenerateDeterministicGuid("Authorization"),Name = "Authorization", IsCommon = true, CreatedAt=seedTime, UpdatedAt=seedTime}
            );
    }
}

public static class GuidHelper
{
    public static Guid GenerateDeterministicGuid(string input)
    {
        return new Guid(
            System.Security.Cryptography.MD5.HashData(
                Encoding.UTF8.GetBytes(input)));
    }
}