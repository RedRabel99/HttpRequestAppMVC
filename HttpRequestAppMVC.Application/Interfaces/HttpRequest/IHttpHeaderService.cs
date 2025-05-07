using HttpRequestAppMVC.Application.ViewModels.HttpRequests;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.Interfaces.HttpRequest;

public interface IHttpHeaderService
{
    public HttpHeader GetOrCreateHttpHeader(string name);
    public HttpHeaderValue GetOrCreateHeaderValue(string value);
}