using HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.Interfaces.HttpRequestList;

public interface IHttpRequestListService
{
    public Guid CreateHttpRequestList(HttpRequestListVm model);
    public Guid EditRequestList(HttpRequestListVm model);
    public void DeleteRequestList(Guid id);
    public ListForHttpRequestListVm GetAllHttpRequestLists();
    public HttpRequestListVm GetHttpRequestListById(Guid id);
}
