using HttpRequestAppMVC.Application.Interfaces.Requests;
using HttpRequestAppMVC.Application.ViewModels.Requests;
using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.Services.RequestServices;

public class HttpHeaderService(
    IRequestRepository requestRepository,
    IRequestHeaderRepository requestHeaderRepository
    ) : IHeaderService
{
    public HeaderValue GetOrCreateHeaderValue(string value)
    {
        var headerValue = requestRepository.GetHeaderValueByValue(value);
        if (headerValue != null)
        {
            return headerValue;
        }
        var newHeaderValue = new HeaderValue { Value = value, IsCommon = false };
        requestRepository.AddHeaderValue(newHeaderValue);
        return newHeaderValue;
    }

    public Header GetOrCreateHttpHeader(string name)
    {
        var header = requestRepository.GetHeaderByName(name);
        if (header != null)
        {
            return header;
        }
        var newHeader = new Header { Name = name, IsCommon = false };
        requestRepository.AddHeader(newHeader);
        return newHeader;
    }

    public List<RequestHeader> UpdateHeaders(List<RequestHeaderVm> requestHeaders, List<Guid> headersToDelete, Guid id)
    {
        foreach(var headerToDeleteId in headersToDelete)
        {
           requestRepository.DeleteRequestHeader(headerToDeleteId);
        }
        var resultRequestHeaders = new List<RequestHeader>();
        foreach(var header in requestHeaders)
        {
            var httpHeader = requestHeaderRepository.GetRequestHeaderById(header.Id);
            if (httpHeader is not null)
            {
                httpHeader.HeaderId = GetOrCreateHttpHeader(header.Header).Id;
                httpHeader.HeaderValueId = GetOrCreateHeaderValue(header.Value).Id;
                httpHeader.RequestId = id;
                var newHeader = requestHeaderRepository.UpdateRequestHeader(httpHeader);
                resultRequestHeaders.Add(newHeader);

            }
            else
            {
                var newHttpHeader = new RequestHeader();
                newHttpHeader.HeaderId = GetOrCreateHttpHeader(header.Header).Id;
                newHttpHeader.HeaderValueId = GetOrCreateHeaderValue(header.Value).Id;
                newHttpHeader.RequestId = id;
                newHttpHeader = requestHeaderRepository.CreateRequestHeader(newHttpHeader);
                resultRequestHeaders.Add(newHttpHeader);
            }
        }
        return resultRequestHeaders;
    }
}
