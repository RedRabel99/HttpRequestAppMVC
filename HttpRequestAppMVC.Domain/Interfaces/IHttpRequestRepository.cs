using HttpRequestAppMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Domain.Interfaces
{
    public interface IHttpRequestRepository
    {
        public Guid AddHttpRequest(HttpRequest httpRequest);
        public HttpRequest GetHttpRequestById(Guid id);
        public Guid UpdateHttpRequest(HttpRequest httpRequest);
        public void DeleteHttpRequest(Guid id);
        public IQueryable<HttpRequest> GetAllHttpRequests();
        public IQueryable<HttpRequest> GetHttpRequestsByRequestListId(Guid requestListId);

        HttpHeader? GetHttpHeaderByName(string name);
        HttpHeaderValue? GetHttpHeaderValueByValue(string value);

        public Guid AddHttpHeader(HttpHeader httpHeader);
        public Guid AddHttpHeaderValue(HttpHeaderValue httpHeaderValue);
    }
}
