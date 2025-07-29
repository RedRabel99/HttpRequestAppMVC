using HttpRequestAppMVC.Application.ViewModels.Requests;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.Interfaces.Requests;

public interface IHeaderService
{
    public Header GetOrCreateHttpHeader(string name);
    public HeaderValue GetOrCreateHeaderValue(string value);
    List<RequestHeader> UpdateHeaders(List<RequestHeaderVm> requestHeaders, List<Guid> headersToDelete, Guid id);
}