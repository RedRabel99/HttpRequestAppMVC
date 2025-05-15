using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Domain.Interfaces;

public interface IHttpRequestListRepository
{
    public IQueryable<HttpRequestList> GetAllHttpRequestLists();
    public HttpRequestList? GetHttpRequestListById(Guid id);
    public Guid CreateHttpRequestList(HttpRequestList requestList);
    public Guid UpdateHttpRequestList(HttpRequestList requestList);
    public void DeleteHttpRequestList(Guid id);
}
