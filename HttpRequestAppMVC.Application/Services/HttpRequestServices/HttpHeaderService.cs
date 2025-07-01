using HttpRequestAppMVC.Application.Interfaces.HttpRequest;
using HttpRequestAppMVC.Application.ViewModels.HttpRequests;
using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.Services.HttpRequestServices;

public class HttpHeaderService(
    IHttpRequestRepository httpRequestRepository,
    IHttpRequestHeaderRepository httpRequestHeaderRepository
    ) : IHttpHeaderService
{
    public HttpHeaderValue GetOrCreateHeaderValue(string value)
    {
        var headerValue = httpRequestRepository.GetHttpHeaderValueByValue(value);
        if (headerValue != null)
        {
            return headerValue;
        }
        var newHeaderValue = new HttpHeaderValue { Value = value, IsCommon = false };
        httpRequestRepository.AddHttpHeaderValue(newHeaderValue);
        return newHeaderValue;
    }

    public HttpHeader GetOrCreateHttpHeader(string name)
    {
        var header = httpRequestRepository.GetHttpHeaderByName(name);
        if (header != null)
        {
            return header;
        }
        var newHeader = new HttpHeader { Name = name, IsCommon = false };
        httpRequestRepository.AddHttpHeader(newHeader);
        return newHeader;
    }

    public List<HttpRequestHeader> UpdateHeaders(List<HttpRequestHeaderVm> httpRequestHeaders, List<Guid> headersToDelete, Guid id)
    {
        foreach(var headerToDeleteId in headersToDelete)
        {
           httpRequestRepository.DeleteHttpRequestHeader(headerToDeleteId);
        }
        var resultRequestHeaders = new List<HttpRequestHeader>();
        foreach(var header in httpRequestHeaders)
        {
            var httpHeader = httpRequestHeaderRepository.GetHttpRequestHeaderById(header.Id);
            if (httpHeader is not null)
            {
                httpHeader.HttpHeaderId = GetOrCreateHttpHeader(header.Header).Id;
                httpHeader.HttpHeaderValueId = GetOrCreateHeaderValue(header.Value).Id;
                httpHeader.HttpRequestId = id;
                var newHeader = httpRequestHeaderRepository.UpdateHttpRequestHeader(httpHeader);
                resultRequestHeaders.Add(newHeader);

            }
            else
            {
                var newHttpHeader = new HttpRequestHeader();
                newHttpHeader.HttpHeaderId = GetOrCreateHttpHeader(header.Header).Id;
                newHttpHeader.HttpHeaderValueId = GetOrCreateHeaderValue(header.Value).Id;
                newHttpHeader.HttpRequestId = id;
                newHttpHeader = httpRequestHeaderRepository.CreateHttpRequestHeader(newHttpHeader);
                resultRequestHeaders.Add(newHttpHeader);
            }
        }
        return resultRequestHeaders;
    }
}
