using AutoMapper;
using AutoMapper.QueryableExtensions;
using HttpRequestAppMVC.Application.Interfaces.HttpRequestList;
using HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;
using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.Services;

public class HttpRequestListService(IHttpRequestListRepository httpRequestListRepository, IMapper mapper) : IHttpRequestListService
{
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

    public Guid CreateHttpRequestList(CreateHttpRequestListVm model)
    {
        var requestList = mapper.Map<HttpRequestList>(model);
        var id = httpRequestListRepository.CreateHttpRequestList(requestList);
        return id;
    }
    public Guid EditRequestList(HttpRequestListVm model)
    {
        var requestList = mapper.Map<HttpRequestList>(model);
        var id = httpRequestListRepository.UpdateHttpRequestList(requestList);
        return id;
    }
    public void DeleteRequestList(Guid id)
    {
        httpRequestListRepository.DeleteHttpRequestList(id);
    }
}