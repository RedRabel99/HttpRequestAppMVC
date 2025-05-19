using HttpRequestAppMVC.Application.ViewModels.HttpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.Interfaces.HttpRequest;

public interface IRequestSenderService
{
    public Task<HttpRequestResponseVm> SendRequest(CreateHttpRequestVm model);
}
