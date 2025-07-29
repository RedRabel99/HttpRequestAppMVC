using HttpRequestAppMVC.Application.ViewModels.RequestLists;

namespace HttpRequestAppMVC.Application.Interfaces.RequestLists;

public interface IRequestListService
{
    public ListForRequestListVm GetAllRequestLists();
    public RequestListVm GetRequestListById(Guid id);
    public Guid CreateRequestList(CreateRequestListVm model);
    public Guid EditRequestList(RequestListVm model);
    public void DeleteRequestList(Guid id);
}
