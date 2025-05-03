using HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;
using HttpRequestAppMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.Interfaces;

public interface IHttpRequestService
{
    public Guid AddRequestList(HttpRequestVm requestListVm);
    public Guid EditRequestList(HttpRequestVm requestListVm);
    public HttpRequestVm GetRequestListById(Guid id);
    public ListForHttpRequestListVm GetAllRequestLists();
}
