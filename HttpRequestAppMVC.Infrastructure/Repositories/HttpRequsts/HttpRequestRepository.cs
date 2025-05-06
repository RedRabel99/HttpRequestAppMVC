using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Infrastructure.Repositories.HttpRequsts;

public class HttpRequestRepository(AppDbContext dbContext) : IHttpRequestRepository
{
    private readonly AppDbContext dbContext = dbContext;

    public Guid AddHttpRequest(HttpRequest httpRequest)
    {
        dbContext.HttpRequests.Add(httpRequest);
        dbContext.SaveChanges();
        return httpRequest.Id;
    }

    public void DeleteHttpRequest(Guid id)
    {
        var request = dbContext.HttpRequests.Find(id);
        if (request != null)
        {
            dbContext.HttpRequests.Remove(request);
            dbContext.SaveChanges();
        }
    }

    public HttpRequest GetHttpRequestById(Guid id)
    {
        var request = dbContext.HttpRequests.FirstOrDefault(i => i.Id == id);
        return request;
    }

    public Guid UpdateHttpRequest(HttpRequest httpRequest)
    {
        throw new NotImplementedException();
    }

    public IQueryable<HttpRequest> GetAllHttpRequests()
    {
        var requests = dbContext.HttpRequests;
        return requests;
    }

    public IQueryable<HttpRequest> GetHttpRequestsByRequestListId(Guid requestListId)
    {
        var requests = dbContext.HttpRequests.Where(i => i.RequestListId == requestListId);
        return requests;
    }

    public Guid AddHtppRequestList(HttpRequestList requestList)
    {
        dbContext.HttpRequestLists.Add(requestList);
        dbContext.SaveChanges();
        return requestList.Id;
    }


    public void MoveHttpRequestToAnotherList(Guid httpRequestId, Guid requestListId)
    {
        var item = dbContext.HttpRequests.FirstOrDefault(i => i.Id == httpRequestId);
        if (item != null)
        {
            item.RequestListId = requestListId;
            dbContext.SaveChanges();
        }
    }

    public void UpdateHttpRequestList(HttpRequestList requestList)
    {
        dbContext.Attach(requestList);
        dbContext.Entry(requestList).Property("Name").IsModified = true;
        dbContext.Entry(requestList).Property("Description").IsModified = true;
        dbContext.SaveChanges();
    }

    public IQueryable<HttpRequestList> GetAllHttpRequestLists()
    {
        var requestLists = dbContext.HttpRequestLists;
        return requestLists;
    }

    public HttpRequestList GetRequestListById(Guid id)
    {
        var requestList = dbContext.HttpRequestLists.FirstOrDefault(r => r.Id == id);
        return requestList;
    }
}
