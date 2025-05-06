using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Infrastructure.Repositories.HttpRequsts;

public class HttpRequestHeaderRepository(AppDbContext appDbContext) : IHttpRequestHeaderRepository
{
    private readonly AppDbContext appDbContext = appDbContext;

    public Guid CreateHttpHeader(HttpHeader httpHeader)
    {
        appDbContext.Add(httpHeader);
        appDbContext.SaveChanges();
        return httpHeader.Id;
    }

    public Guid CreateHttpHeaderValue(HttpHeaderValue httpHeaderValue)
    {
        appDbContext.Add(httpHeaderValue);
        appDbContext.SaveChanges();
        return httpHeaderValue.Id;
    }

    public Guid CreateHttpRequestHeader(HttpRequestHeader requestHeader)
    {
        appDbContext.Add(requestHeader);
        appDbContext.SaveChanges();
        return requestHeader.Id;
    }

    public void DeleteHttpRequestHeader(Guid id)
    {
        var httpRequestHeader = appDbContext.HttpRequestHeaders.Find(id);
        if (httpRequestHeader != null)
        {
            appDbContext.Remove(httpRequestHeader);
            appDbContext.SaveChanges();
        }
    }

    public void DeleteUncommonHttpHeader(Guid id)
    {
        var httpHeader = appDbContext.HttpHeaders.Find(id);
        if (httpHeader != null && !httpHeader.IsCommon)
        {
            appDbContext.Remove(httpHeader);
            appDbContext.SaveChanges();
        }
    }

    public void DeleteUncommonHttpHeaderValue(Guid id)
    {
        var httpHeaderValue = appDbContext.HttpHeaders.Find(id);
        if(httpHeaderValue != null && !httpHeaderValue.IsCommon)
        {
            appDbContext.Remove(httpHeaderValue);
            appDbContext.SaveChanges();
        }
    }

    public IQueryable<HttpHeader> GetAllHttpHeaders()
    {
        var httpHeaders = appDbContext.HttpHeaders;
        return httpHeaders;
    }

    public IQueryable<HttpHeaderValue> GetAllHttpHeaderValues()
    {
        var httpHeaderValues =  appDbContext.HttpHeaderValues;
        return httpHeaderValues;
    }

    public HttpHeader GetHttpHeaderById(Guid id)
    {
        var httpHeader = appDbContext.HttpHeaders.FirstOrDefault(h => h.Id == id);
        return httpHeader;
    }

    public HttpHeader GetHttpHeaderByName(string name)
    {
        var httpHeader = appDbContext.HttpHeaders.FirstOrDefault(h => h.Name == name);
        return httpHeader;
    }

    public HttpHeaderValue GetHttpHeaderValueById(Guid id)
    {
        var httpHeaderValue = appDbContext.HttpHeaderValues.FirstOrDefault(h => h.Id == id);
        return httpHeaderValue;
    }

    public HttpHeaderValue GetHttpHeaderValueByValue(string value)
    {
        var httpHeaderValue = appDbContext.HttpHeaderValues.FirstOrDefault(h => h.Value == value);
        return httpHeaderValue;
    }

    public HttpRequestHeader GetHttpRequestHeaderById(Guid id)
    {
        var httpRequestHeader = appDbContext.HttpRequestHeaders.FirstOrDefault(h => h.Id == id);
        return httpRequestHeader;
    }

    public IQueryable<HttpRequestHeader> GetHttpRequestHeadersByHttpRequestId(Guid id)
    {
        var httpRequestHeaders = appDbContext.HttpRequestHeaders.Where(h => h.HttpRequestId == id);
        return httpRequestHeaders;
    }

    public Guid UpdateHttpRequestHeader(HttpRequestHeader requestHeader)
    {
        appDbContext.Attach(requestHeader);
        appDbContext.Entry(requestHeader).Property("HttpHeaderId").IsModified = true;
        appDbContext.Entry(requestHeader).Property("HttpHeaderValueId").IsModified = true;
        appDbContext.SaveChanges();
        return requestHeader.Id;
    }
}
