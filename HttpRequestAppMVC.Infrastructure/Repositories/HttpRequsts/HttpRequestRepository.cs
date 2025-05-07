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

    public HttpRequestList GetRequestListById(Guid id)
    {
        var requestList = dbContext.HttpRequestLists.FirstOrDefault(r => r.Id == id);
        return requestList;
    }

    public HttpHeader? GetHttpHeaderByName(string name)
    {
        var header = dbContext.HttpHeaders.FirstOrDefault(h => h.Name == name);
        return header;
    }

    public HttpHeaderValue? GetHttpHeaderValueByValue(string value)
    {
        var header = dbContext.HttpHeaderValues.FirstOrDefault(h => h.Value == value);
        return header;
    }

    public HttpHeader AddHttpHeader(HttpHeader httpHeader)
    {
        dbContext.HttpHeaders.Add(httpHeader);
        dbContext.SaveChanges();
        return httpHeader;
    }

    public HttpHeaderValue AddHttpHeaderValue(HttpHeaderValue httpHeaderValue)
    {
        dbContext.HttpHeaderValues.Add(httpHeaderValue);
        dbContext.SaveChanges();
        return httpHeaderValue;
    }
}
