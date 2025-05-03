using HttpRequestAppMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Domain.Interfaces;

public interface IHttpRequestListRepository
{
    public Guid CreateHttpRequestList(HttpRequestList requestList);
    public void DeleteHttpRequestList(Guid id);
    public IQueryable<HttpRequestList> GetAllHttpRequestLists();
    public HttpRequestList GetHttpRequestListById(Guid id);
    public Guid UpdateHttpRequestList(HttpRequestList requestList);
}
