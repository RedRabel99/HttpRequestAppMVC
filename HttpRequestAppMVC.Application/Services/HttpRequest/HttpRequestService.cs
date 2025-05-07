using AutoMapper;
using HttpRequestAppMVC.Application.Interfaces.HttpRequest;
using HttpRequestAppMVC.Application.ViewModels.HttpRequests;
using HttpRequestAppMVC.Domain.Interfaces;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.Services.HttpRequest
{
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

        public Guid AddHttpRequest(HttpRequestVm httpRequestVm)
        {
            var httpRequest = mapper.Map<HttpRequest>(httpRequestVm);
            foreach (var header in httpRequest.HttpRequestHeaders)
            {
                HttpHeader existingHttpHeader = httpRequestRepository.GetHttpHeaderByName(header.HttpHeader.Name);
                HttpHeaderValue existingHttpHeaderValue = httpRequestRepository.GetHttpHeaderValueByValue(header.HttpHeaderValue.Value);
            }            
            httpRequest.RequestList = httpRequestRepository.GetAllHttpRequestLists().ToList()[0];
            var id = httpRequestRepository.AddHttpRequest(httpRequest);
            return id;
        }

        public List<HttpRequestVm> GetAllHttpRequestByHttpRequestListId(Guid requestListId)
        {
            throw new NotImplementedException();
        }

        public HttpRequestResponseVm GetByIdAndSendRequest(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveHttpRequest(HttpRequestVm httpRequestVm)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpRequestResponseVm> SendHttpRequest(HttpRequestVm httpRequestVm)
        {
            var response = await requestSenderService.SendRequest(httpRequestVm);
            return response;
        }
    }
}
