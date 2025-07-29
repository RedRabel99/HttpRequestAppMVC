using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Infrastructure.Repositories.Requests;

public class RequestHeaderRepository(AppDbContext appDbContext) : IRequestHeaderRepository
{
    private readonly AppDbContext appDbContext = appDbContext;

    public Guid CreateHeader(Header header)
    {
        appDbContext.Add(header);
        appDbContext.SaveChanges();
        return header.Id;
    }

    public Guid CreateHeaderValue(HeaderValue headerValue)
    {
        appDbContext.Add(headerValue);
        appDbContext.SaveChanges();
        return headerValue.Id;
    }

    public RequestHeader CreateRequestHeader(RequestHeader requestHeader)
    {
        appDbContext.Add(requestHeader);
        appDbContext.SaveChanges();
        return requestHeader;
    }

    public void DeleteRequestHeader(Guid id)
    {
        var requestHeader = appDbContext.RequestHeaders.Find(id);
        if (requestHeader != null)
        {
            appDbContext.Remove(requestHeader);
            appDbContext.SaveChanges();
        }
    }

    public void DeleteUncommonHeader(Guid id)
    {
        var header = appDbContext.Headers.Find(id);
        if (header != null && !header.IsCommon)
        {
            appDbContext.Remove(header);
            appDbContext.SaveChanges();
        }
    }

    public void DeleteUncommonHeaderValue(Guid id)
    {
        var headerValue = appDbContext.Headers.Find(id);
        if(headerValue != null && !headerValue.IsCommon)
        {
            appDbContext.Remove(headerValue);
            appDbContext.SaveChanges();
        }
    }

    public IQueryable<Header> GetAllHeaders()
    {
        var headers = appDbContext.Headers;
        return headers;
    }

    public IQueryable<HeaderValue> GetAllHeaderValues()
    {
        var headerValues =  appDbContext.HeaderValues;
        return headerValues;
    }

    public Header GetHeaderById(Guid id)
    {
        var header = appDbContext.Headers.FirstOrDefault(h => h.Id == id);
        return header;
    }

    public Header GetHeaderByName(string name)
    {
        var header = appDbContext.Headers.FirstOrDefault(h => h.Name == name);
        return header;
    }

    public HeaderValue GetHeaderValueById(Guid id)
    {
        var headerValue = appDbContext.HeaderValues.FirstOrDefault(h => h.Id == id);
        return headerValue;
    }

    public HeaderValue GetHeaderValueByValue(string value)
    {
        var headerValue = appDbContext.HeaderValues.FirstOrDefault(h => h.Value == value);
        return headerValue;
    }

    public RequestHeader GetRequestHeaderById(Guid id)
    {
        var requestHeader = appDbContext.RequestHeaders.FirstOrDefault(h => h.Id == id);
        return requestHeader;
    }

    public IQueryable<RequestHeader> GetRequestHeadersByRequestId(Guid id)
    {
        var requestHeaders = appDbContext.RequestHeaders.Where(h => h.RequestId == id);
        return requestHeaders;
    }

    public RequestHeader UpdateRequestHeader(RequestHeader requestHeader)
    {
        appDbContext.Attach(requestHeader);
        appDbContext.Entry(requestHeader).Property("HeaderId").IsModified = true;
        appDbContext.Entry(requestHeader).Property("HeaderValueId").IsModified = true;
        appDbContext.SaveChanges();
        return requestHeader;
    }
}
