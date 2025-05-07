using HttpRequestAppMVC.Application.Interfaces.HttpRequest;
using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HttpRequestAppMVC.Application.Services.HttpRequestServices;

public class HttpHeaderService : IHttpHeaderService
{
    private readonly IHttpRequestRepository httpRequestRepository;

    public HttpHeaderService(IHttpRequestRepository httpRequestRepository)
    {
        this.httpRequestRepository = httpRequestRepository;
    }
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
}
