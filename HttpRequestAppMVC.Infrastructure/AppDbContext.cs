using HttpRequestAppMVC.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace HttpRequestAppMVC.Infrastructure;

public class AppDbContext : IdentityDbContext
{   
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<RequestList> RequestLists { get; set; }
    public DbSet<Request> Requests { get; set; }
    public DbSet<RequestHeader> RequestHeaders { get; set; }
    public DbSet<Header> Headers { get; set; }
    public DbSet<HeaderValue> HeaderValues { get; set; }
    public DbSet<Response> Responses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<RequestList>()
            .Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Entity<Request>()
            .Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Entity<RequestHeader>()
            .Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Entity<Response>()
            .Property(r => r.Id).ValueGeneratedOnAdd();
        builder.Entity<HeaderValue>()
            .Property(h => h.Id).ValueGeneratedOnAdd();
        builder.Entity<Header>()
            .Property(h => h.Id).ValueGeneratedOnAdd();

        builder.Entity<RequestList>()
            .HasMany(r => r.Requests)
            .WithOne(r => r.RequestList)
            .HasForeignKey(r => r.RequestListId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Request>()
            .HasMany(r => r.RequestHeaders)
            .WithOne(r => r.Request)
            .HasForeignKey(r => r.RequestId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Request>()
            .HasMany(r => r.ResponseHistory)
            .WithOne(r => r.Request)
            .HasForeignKey(r => r.RequestId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<RequestHeader>()
            .HasOne(h => h.Header)
            .WithMany(h => h.RequestHeaders)
            .HasForeignKey(h => h.HeaderId)
            .OnDelete(DeleteBehavior.NoAction);
        builder.Entity<RequestHeader>()
            .HasOne(h => h.HeaderValue)
            .WithMany(h => h.RequestHeaders)
            .HasForeignKey(h => h.HeaderValueId)
            .OnDelete(DeleteBehavior.NoAction);
        var seedTime = new DateTime(2025, 1, 1,0,0,0, DateTimeKind.Utc);
        builder.Entity<Header>().HasData(
            //Generating deterministic Guid to prevent insertion every time onModelCreating is called.
            new Header {Id = GuidHelper.GenerateDeterministicGuid("Content-Type"),Name = "Content-Type", IsCommon=true, CreatedAt=seedTime, UpdatedAt=seedTime},
            new Header {Id = GuidHelper.GenerateDeterministicGuid("Authorization"),Name = "Authorization", IsCommon = true, CreatedAt=seedTime, UpdatedAt=seedTime}
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