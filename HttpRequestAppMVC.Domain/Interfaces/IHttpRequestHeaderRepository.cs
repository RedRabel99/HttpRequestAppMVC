using HttpRequestAppMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Domain.Interfaces;

public interface IHttpRequestHeaderRepository
{
    public Guid CreateHttpRequestHeader(HttpRequestHeader requestHeader);
    public IQueryable<HttpRequestHeader> GetHttpRequestHeadersByHttpRequestId(Guid id);
    public HttpRequestHeader GetHttpRequestHeaderById(Guid id);
    public Guid UpdateHttpRequestHeader(HttpRequestHeader requestHeader);
    public void DeleteHttpRequestHeader(Guid id);

    public Guid CreateHttpHeader(HttpHeader httpHeader);
    public IQueryable<HttpHeader> GetAllHttpHeaders();
    public HttpHeader GetHttpHeaderByName(string name);
    public HttpHeader GetHttpHeaderById(Guid id);
    public void DeleteUncommonHttpHeader(Guid id);

    public Guid CreateHttpHeaderValue(HttpHeaderValue httpHeaderValue);
    public IQueryable<HttpHeaderValue> GetAllHttpHeaderValues();
    public HttpHeaderValue GetHttpHeaderValueByValue(string value);
    public HttpHeaderValue GetHttpHeaderValueById(Guid id);
    public void DeleteUncommonHttpHeaderValue(Guid id);
}
