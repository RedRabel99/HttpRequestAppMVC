using AutoMapper;
using AutoMapper.QueryableExtensions;
using HttpRequestAppMVC.Application.Interfaces.RequestLists;
using HttpRequestAppMVC.Application.ViewModels.RequestLists;
using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.Services;

public class RequestListService(IRequestListRepository requestListRepository, IMapper mapper) : IRequestListService
{
    public ListForRequestListVm GetAllRequestLists()
    {
        var requestLists = requestListRepository.GetAllRequestLists()
            .ProjectTo<RequestListVm>(mapper.ConfigurationProvider).ToList();

        return new ListForRequestListVm
        {
            RequestLists = requestLists,
            Count = requestLists.Count
        };
    }

    public RequestListVm GetRequestListById(Guid id)
    {
        var requestList = requestListRepository.GetRequestListById(id);
        return mapper.Map<RequestListVm>(requestList);
    }

    public Guid CreateRequestList(CreateRequestListVm model)
    {
        var requestList = mapper.Map<RequestList>(model);
        var id = requestListRepository.CreateRequestList(requestList);
        return id;
    }
    public Guid EditRequestList(RequestListVm model)
    {
        var requestList = mapper.Map<RequestList>(model);
        var id = requestListRepository.UpdateRequestList(requestList);
        return id;
    }
    public void DeleteRequestList(Guid id)
    {
        requestListRepository.DeleteRequestList(id);
    }
}