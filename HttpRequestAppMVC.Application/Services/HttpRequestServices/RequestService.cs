using AutoMapper;
using AutoMapper.QueryableExtensions;
using HttpRequestAppMVC.Application.Interfaces.Requests;
using HttpRequestAppMVC.Application.ViewModels.Requests;
using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.Services.RequestServices;

public class RequestService : IRequestService
{
    private readonly IRequestRepository requestRepository;
    private readonly IRequestSenderService requestSenderService;
    private readonly IHeaderService headerService;
    private readonly IMapper mapper;

    public RequestService(IRequestRepository requestRepository, IRequestSenderService requestSenderService, IMapper mapper, IHeaderService headerService)
    {
        this.requestRepository = requestRepository;
        this.requestSenderService = requestSenderService;
        this.headerService = headerService;
        this.mapper = mapper;
        
    }

    public Guid AddRequest(CreateRequestVm requestVm)
    {
        var x = new List<RequestHeader>();
        foreach(var requestheader in requestVm.RequestHeaders)
        {
            x.Add(new RequestHeader {
                Header = headerService.GetOrCreateHttpHeader(requestheader.Header),
                HeaderValue = headerService.GetOrCreateHeaderValue(requestheader.Value)
            });

        }
        var request = mapper.Map<Request>(requestVm);
        request.RequestHeaders = x;
        var id = requestRepository.AddRequest(request);

        return id;
    }

    public Guid UpdateRequest(RequestVm request)
    {
        //TODO: refactor updating

        var model = mapper.Map<Request>(request);
        var id = requestRepository.UpdateRequest(model);

        var newHeaders = headerService.UpdateHeaders(request.RequestHeaders, request.HeadersToDelete, request.Id);

        foreach (var header in newHeaders)
        {
            header.RequestId = id;
        }
        return id;
    }

    public List<RequestVm> GetAllRequestByHttpRequestListId(Guid requestListId)
    {
        var requestList = requestRepository.GetRequestsByRequestListId(requestListId);
        var requestListVm = requestList.ProjectTo<RequestVm>(mapper.ConfigurationProvider).ToList();
        return requestListVm;
    }

    public RequestResponseVm GetByIdAndSendRequest(Guid id)
    {
        throw new NotImplementedException();
    }

    public RequestVm GetRequestById(Guid id)
    {
        var request = requestRepository.GetRequestById(id);
        var requestVm = mapper.Map<RequestVm>(request);
        return requestVm;
    }

    public void RemoveRequest(Guid id)
    {
        requestRepository.DeleteRequest(id);
    }

    public async Task<RequestResponseVm> SendRequest(CreateRequestVm requestVm)
    {
        var response = await requestSenderService.SendRequest(requestVm);
        return response;
    }
}
