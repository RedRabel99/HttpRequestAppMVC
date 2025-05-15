using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpRequestAppMVC.Infrastructure.Repositories.HttpRequsts;

public class HttpRequestListRepository(AppDbContext dbContext) : IHttpRequestListRepository
{
    public IQueryable<HttpRequestList> GetAllHttpRequestLists()
    {
        return dbContext.HttpRequestLists.Include(rl => rl.HttpRequests);
    }

    public HttpRequestList? GetHttpRequestListById(Guid id)
    {
        return dbContext.HttpRequestLists
            .Include(rl => rl.HttpRequests)
            .FirstOrDefault(r => r.Id == id);
    }

    public Guid CreateHttpRequestList(HttpRequestList requestList)
    {
        dbContext.HttpRequestLists.Add(requestList);
        dbContext.SaveChanges();
        return requestList.Id;
    }

    public Guid UpdateHttpRequestList(HttpRequestList requestList)
    {
        dbContext.Attach(requestList);
        dbContext.Entry(requestList).Property(r => r.Name).IsModified = true;
        dbContext.Entry(requestList).Property(r => r.Description).IsModified = true;
        dbContext.SaveChanges();
        return requestList.Id;
    }

    public void DeleteHttpRequestList(Guid id)
    {
        var httpRequestList = dbContext.HttpRequestLists.Find(id);
        if (httpRequestList != null)
        {
            dbContext.HttpRequestLists.Remove(httpRequestList);
            dbContext.SaveChanges();
        }
    }
}
