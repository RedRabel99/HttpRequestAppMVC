using HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;

namespace HttpRequestAppMVC.Application.Interfaces.HttpRequestList;

public interface IHttpRequestListService
{
    public ListForHttpRequestListVm GetAllHttpRequestLists();
    public HttpRequestListVm GetHttpRequestListById(Guid id);
    public Guid CreateHttpRequestList(CreateHttpRequestListVm model);
    public Guid EditRequestList(HttpRequestListVm model);
    public void DeleteRequestList(Guid id);
}
