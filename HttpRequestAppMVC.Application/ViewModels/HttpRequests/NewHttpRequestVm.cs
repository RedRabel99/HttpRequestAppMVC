using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.ViewModels.HttpRequests;

public class NewHttpRequestVm
{
    public HttpRequestVm HttpRequest {  get; set; }
    public HttpRequestResponseVm? HttpResponse { get; set; } = null;
}
