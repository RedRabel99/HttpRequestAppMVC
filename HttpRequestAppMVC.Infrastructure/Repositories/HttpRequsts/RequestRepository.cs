using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpRequestAppMVC.Infrastructure.Repositories.Requests;

public class RequestRepository(AppDbContext dbContext) : IRequestRepository
{
    private readonly AppDbContext dbContext = dbContext;

    public Guid AddRequest(Request request)
    {
        dbContext.Requests.Add(request);
        dbContext.SaveChanges();
        return request.Id;
    }

    public void DeleteRequest(Guid id)
    {
        var request = dbContext.Requests.Find(id);
        if (request != null)
        {
            dbContext.Requests.Remove(request);
            dbContext.SaveChanges();
        }
    }

    public Request GetRequestById(Guid id)
    {
        var request = dbContext.Requests
            .Include(r => r.RequestHeaders)
                .ThenInclude(h => h.Header)
            .Include(r => r.RequestHeaders)
                .ThenInclude(h => h.HeaderValue)
            .FirstOrDefault(i => i.Id == id);
        return request;
    }

    public Guid UpdateRequest(Request request)
    {
        dbContext.Attach(request);
        dbContext.Entry(request).Property(r => r.Name).IsModified = true;
        dbContext.Entry(request).Property(r => r.Url).IsModified = true;
        dbContext.Entry(request).Property(r => r.Method).IsModified = true;
        dbContext.Entry(request).Property(r => r.Body).IsModified = true;
        dbContext.Entry(request).Property(r => r.RequestListId).IsModified = true;
        //dbContext.Entry(httpRequest).Property(r => r.HttpRequestHeaders).IsModified = true;
        dbContext.Entry(request).Property(r => r.UpdatedAt).IsModified = true;
        dbContext.SaveChanges();
        return request.Id;
    }

    public IQueryable<Request> GetAllRequests()
    {
        var requests = dbContext.Requests;
        return requests;
    }

    public IQueryable<Request> GetRequestsByRequestListId(Guid requestListId)
    {
        var requests = dbContext.Requests.Where(i => i.RequestListId == requestListId);
        return requests;
    }

    public RequestList GetRequestListById(Guid id)
    {
        var requestList = dbContext.RequestLists.FirstOrDefault(r => r.Id == id);
        return requestList;
    }

    public Header? GetHeaderByName(string name)
    {
        var header = dbContext.Headers.FirstOrDefault(h => h.Name == name);
        return header;
    }

    public HeaderValue? GetHeaderValueByValue(string value)
    {
        var header = dbContext.HeaderValues.FirstOrDefault(h => h.Value == value);
        return header;
    }

    public Header AddHeader(Header header)
    {
        dbContext.Headers.Add(header);
        dbContext.SaveChanges();
        return header;
    }

    public HeaderValue AddHeaderValue(HeaderValue headerValue)
    {
        dbContext.HeaderValues.Add(headerValue);
        dbContext.SaveChanges();
        return headerValue;
    }

    public void DeleteRequestHeader(Guid id)
    {
        var header = dbContext.RequestHeaders.Find(id);
        if (header != null)
        {
            dbContext.RequestHeaders.Remove(header);
            dbContext.SaveChanges();
        }
    }

    public RequestHeader CreateRequestHeader(RequestHeader requestHeader)
    {
        dbContext.RequestHeaders.Add(requestHeader);
        dbContext.SaveChanges();
        return requestHeader;
    }
}
