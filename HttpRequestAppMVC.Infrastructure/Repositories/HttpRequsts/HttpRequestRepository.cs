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
        var request = dbContext.HttpRequests
            .Include(r => r.HttpRequestHeaders)
                .ThenInclude(h => h.HttpHeader)
            .Include(r => r.HttpRequestHeaders)
                .ThenInclude(h => h.HttpHeaderValue)
            .FirstOrDefault(i => i.Id == id);
        return request;
    }

    public Guid UpdateHttpRequest(HttpRequest httpRequest)
    {
        dbContext.Attach(httpRequest);
        dbContext.Entry(httpRequest).Property(r => r.Name).IsModified = true;
        dbContext.Entry(httpRequest).Property(r => r.Url).IsModified = true;
        dbContext.Entry(httpRequest).Property(r => r.Method).IsModified = true;
        dbContext.Entry(httpRequest).Property(r => r.Body).IsModified = true;
        dbContext.Entry(httpRequest).Property(r => r.RequestListId).IsModified = true;
        //dbContext.Entry(httpRequest).Property(r => r.HttpRequestHeaders).IsModified = true;
        dbContext.Entry(httpRequest).Property(r => r.UpdatedAt).IsModified = true;
        dbContext.SaveChanges();
        return httpRequest.Id;
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

    public void DeleteHttpRequestHeader(Guid id)
    {
        var header = dbContext.HttpRequestHeaders.Find(id);
        if (header != null)
        {
            dbContext.HttpRequestHeaders.Remove(header);
            dbContext.SaveChanges();
        }
    }

    public HttpRequestHeader CreateHttpRequestHeader(HttpRequestHeader requestHeader)
    {
        dbContext.HttpRequestHeaders.Add(requestHeader);
        dbContext.SaveChanges();
        return requestHeader;
    }
}
