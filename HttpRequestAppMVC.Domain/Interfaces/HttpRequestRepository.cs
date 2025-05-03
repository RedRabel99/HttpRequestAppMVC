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
        public IQueryable<HttpRequestList> GetAllHttpRequestLists();
        public HttpRequestList GetRequestListById(Guid id);
        public Guid AddHtppRequestList(HttpRequestList requestList);

        public void MoveHttpRequestToAnotherList(Guid httpRequestId, Guid requestListId);

        public void UpdateHttpRequestList(HttpRequestList requestList);


    }
}
