using AutoMapper;
using AutoMapper.QueryableExtensions;
using HttpRequestAppMVC.Application.Interfaces;
using HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;
using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.Services;

public class HttpRequestService(IHttpRequestRepository httpRequestRepository, IMapper mapper) : IHttpRequestService
{
    private readonly IHttpRequestRepository httpRequestRepository = httpRequestRepository;
    private readonly IMapper mapper = mapper;

    public Guid AddRequestList(HttpRequestVm requestListVm)
    {
        var requestList = mapper.Map<HttpRequestList>(requestListVm);
        var id = httpRequestRepository.AddHtppRequestList(requestList);
        return requestList.Id;
    }

    public Guid EditRequestList(HttpRequestVm requestListVm)
    {
        var requestListModel = mapper.Map<HttpRequestList>(requestListVm);
        httpRequestRepository.UpdateHttpRequestList(requestListModel);
        return requestListModel.Id;
    }

    public ListForHttpRequestListVm GetAllRequestLists()
    {
        var requestList = httpRequestRepository.GetAllHttpRequestLists()
            .ProjectTo<HttpRequestListVm>(mapper.ConfigurationProvider).ToList();

        return new ListForHttpRequestListVm
        {
            HttpRequestLists = requestList,
            Count = requestList.Count
        };
    }

    public HttpRequestVm GetRequestListById(Guid id)
    {
        var requestList = httpRequestRepository.GetRequestListById(id);
        return mapper.Map<HttpRequestVm>(requestList);
    }
}
