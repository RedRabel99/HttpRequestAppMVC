using HttpRequestAppMVC.Application.ViewModels.Requests;

namespace HttpRequestAppMVC.Application.Interfaces.Requests;

public interface IRequestService
{
    public Guid AddRequest(CreateRequestVm requestVm);
    public RequestVm GetRequestById(Guid id);
    public void RemoveRequest(Guid id);
    public List<RequestVm> GetAllRequestByHttpRequestListId(Guid requestListId);
    public RequestResponseVm GetByIdAndSendRequest(Guid id);
    public Task<RequestResponseVm> SendRequest(CreateRequestVm requestVm);
    public Guid UpdateRequest(RequestVm request);
}
