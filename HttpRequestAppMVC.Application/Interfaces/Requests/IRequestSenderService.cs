using HttpRequestAppMVC.Application.ViewModels.Requests;

namespace HttpRequestAppMVC.Application.Interfaces.Requests;

public interface IRequestSenderService
{
    public Task<RequestResponseVm> SendRequest(CreateRequestVm model);
}
