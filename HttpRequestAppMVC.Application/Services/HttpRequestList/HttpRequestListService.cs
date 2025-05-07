using AutoMapper;
using AutoMapper.QueryableExtensions;
using HttpRequestAppMVC.Application.Interfaces.HttpRequestList;
using HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;
using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.Services.HttpRequestList;

public class HttpRequestListService(IHttpRequestListRepository httpRequestListRepository, IMapper mapper) : IHttpRequestListService
{
    private readonly IHttpRequestListRepository httpRequestListRepository = httpRequestListRepository;
    private readonly IMapper mapper = mapper;

    public Guid CreateHttpRequestList(HttpRequestListVm model)
    {
        var requestList = mapper.Map<HttpRequestList>(model);
        var id = httpRequestListRepository.CreateHttpRequestList(requestList);
        return id;
    }

    public void DeleteRequestList(Guid id)
    {
        httpRequestListRepository.DeleteHttpRequestList(id);
    }

    public Guid EditRequestList(HttpRequestListVm model)
    {
        var requestList = mapper.Map<HttpRequestList>(model);
        var id = httpRequestListRepository.UpdateHttpRequestList(requestList);
        return requestList.Id;
    }

    public ListForHttpRequestListVm GetAllHttpRequestLists()
    {
        var httpRequestLists = httpRequestListRepository.GetAllHttpRequestLists()
            .ProjectTo<HttpRequestListVm>(mapper.ConfigurationProvider).ToList();
        return new ListForHttpRequestListVm
        {
            HttpRequestLists = httpRequestLists,
            Count = httpRequestLists.Count
        };
    }

    public HttpRequestListVm GetHttpRequestListById(Guid id)
    {
        var httpRequestList = httpRequestListRepository.GetHttpRequestListById(id);
        return mapper.Map<HttpRequestListVm>(httpRequestList);
    }
}
