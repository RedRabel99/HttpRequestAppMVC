using HttpRequestAppMVC.Application.Interfaces.HttpRequest;
using HttpRequestAppMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.Services.HttpRequest
{
    internal class HttpHeaderService : IHttpHeaderService
    {
        public HttpHeaderValue GetOrCreateHeaderValue(string value)
        {
            throw new NotImplementedException();
        }

        public HttpHeader GetOrCreateHttpHeader(string name)
        {
            throw new NotImplementedException();
        }
    }
}
