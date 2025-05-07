using HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;
using HttpRequestAppMVC.Application.ViewModels.HttpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.Interfaces.HttpRequest;

public interface IHttpRequestService
{
    public Guid AddHttpRequest(HttpRequestVm httpRequestVm);
    public void RemoveHttpRequest(HttpRequestVm httpRequestVm);
    public List<HttpRequestVm> GetAllHttpRequestByHttpRequestListId(Guid requestListId);
    public HttpRequestResponseVm GetByIdAndSendRequest(Guid id);

    public Task<HttpRequestResponseVm> SendHttpRequest(HttpRequestVm httpRequestVm);
}
