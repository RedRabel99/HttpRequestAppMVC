using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpRequestAppMVC.Infrastructure.Repositories.Requests;

public class HttpRequestListRepository(AppDbContext dbContext) : IRequestListRepository
{
    public IQueryable<RequestList> GetAllRequestLists()
    {
        return dbContext.RequestLists.Include(rl => rl.Requests);
    }

    public RequestList? GetRequestListById(Guid id)
    {
        return dbContext.RequestLists
            .Include(rl => rl.Requests)
            .FirstOrDefault(r => r.Id == id);
    }

    public Guid CreateRequestList(RequestList requestList)
    {
        dbContext.RequestLists.Add(requestList);
        dbContext.SaveChanges();
        return requestList.Id;
    }

    public Guid UpdateRequestList(RequestList requestList)
    {
        dbContext.Attach(requestList);
        dbContext.Entry(requestList).Property(r => r.Name).IsModified = true;
        dbContext.Entry(requestList).Property(r => r.Description).IsModified = true;
        dbContext.SaveChanges();
        return requestList.Id;
    }

    public void DeleteRequestList(Guid id)
    {
        var httpRequestList = dbContext.RequestLists.Find(id);
        if (httpRequestList != null)
        {
            dbContext.RequestLists.Remove(httpRequestList);
            dbContext.SaveChanges();
        }
    }
}
