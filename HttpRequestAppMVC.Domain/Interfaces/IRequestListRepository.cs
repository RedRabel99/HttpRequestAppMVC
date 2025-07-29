using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Domain.Interfaces;

public interface IRequestListRepository
{
    public IQueryable<RequestList> GetAllRequestLists();
    public RequestList? GetRequestListById(Guid id);
    public Guid CreateRequestList(RequestList requestList);
    public Guid UpdateRequestList(RequestList requestList);
    public void DeleteRequestList(Guid id);
}
