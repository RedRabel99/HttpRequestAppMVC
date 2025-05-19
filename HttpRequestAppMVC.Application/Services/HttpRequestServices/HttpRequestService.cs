using AutoMapper;
using AutoMapper.QueryableExtensions;
using HttpRequestAppMVC.Application.Interfaces.HttpRequest;
using HttpRequestAppMVC.Application.ViewModels.HttpRequests;
using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.Services.HttpRequestServices;

public class HttpRequestService : IHttpRequestService
{
    private readonly IHttpRequestRepository httpRequestRepository;
    private readonly IRequestSenderService requestSenderService;
    private readonly IHttpHeaderService headerService;
    private readonly IMapper mapper;

    public HttpRequestService(IHttpRequestRepository httpRequestRepository, IRequestSenderService requestSenderService, IMapper mapper, IHttpHeaderService headerService)
    {
        this.httpRequestRepository = httpRequestRepository;
        this.requestSenderService = requestSenderService;
        this.headerService = headerService;
        this.mapper = mapper;
        
    }

    public Guid AddHttpRequest(CreateHttpRequestVm httpRequestVm)
    {
        var x = new List<HttpRequestHeader>();
        foreach(var requestheader in httpRequestVm.HttpRequestHeaders)
        {
            x.Add(new HttpRequestHeader {
                HttpHeader = headerService.GetOrCreateHttpHeader(requestheader.Header),
                HttpHeaderValue = headerService.GetOrCreateHeaderValue(requestheader.Value)
            });

        }
        var httpRequest = mapper.Map<HttpRequest>(httpRequestVm);
        httpRequest.HttpRequestHeaders = x;
        var id = httpRequestRepository.AddHttpRequest(httpRequest);

        return id;
    }

    public List<HttpRequestVm> GetAllHttpRequestByHttpRequestListId(Guid requestListId)
    {
        var httpRequestList = httpRequestRepository.GetHttpRequestsByRequestListId(requestListId);
        var httpRequestListVm = httpRequestList.ProjectTo<HttpRequestVm>(mapper.ConfigurationProvider).ToList();
        return httpRequestListVm;
    }

    public HttpRequestResponseVm GetByIdAndSendRequest(Guid id)
    {
        throw new NotImplementedException();
    }

    public HttpRequestVm GetHttpRequestById(Guid id)
    {
        var httpRequest = httpRequestRepository.GetHttpRequestById(id);
        var httpRequestVm = mapper.Map<HttpRequestVm>(httpRequest);
        return httpRequestVm;
    }

    public void RemoveHttpRequest(HttpRequestVm httpRequestVm)
    {
        httpRequestRepository.DeleteHttpRequest(httpRequestVm.Id);
    }

    public async Task<HttpRequestResponseVm> SendHttpRequest(CreateHttpRequestVm httpRequestVm)
    {
        var response = await requestSenderService.SendRequest(httpRequestVm);
        return response;
    }
}
