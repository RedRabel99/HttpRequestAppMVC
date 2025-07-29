using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Domain.Interfaces;

public interface IRequestHeaderRepository
{
    public RequestHeader CreateRequestHeader(RequestHeader requestHeader);
    public IQueryable<RequestHeader> GetRequestHeadersByRequestId(Guid id);
    public RequestHeader GetRequestHeaderById(Guid id);
    public RequestHeader UpdateRequestHeader(RequestHeader requestHeader);
    public void DeleteRequestHeader(Guid id);

    public Guid CreateHeader(Header header);
    public IQueryable<Header> GetAllHeaders();
    public Header GetHeaderByName(string name);
    public Header GetHeaderById(Guid id);
    public void DeleteUncommonHeader(Guid id);

    public Guid CreateHeaderValue(HeaderValue headerValue);
    public IQueryable<HeaderValue> GetAllHeaderValues();
    public HeaderValue GetHeaderValueByValue(string value);
    public HeaderValue GetHeaderValueById(Guid id);
    public void DeleteUncommonHeaderValue(Guid id);
}
