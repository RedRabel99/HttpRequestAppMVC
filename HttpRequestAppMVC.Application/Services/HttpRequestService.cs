using AutoMapper;
using HttpRequestAppMVC.Application.Interfaces;
using HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;
using HttpRequestAppMVC.Application.ViewModels.HttpRequests;
using HttpRequestAppMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.Services
{
    public class HttpRequestService(IHttpRequestRepository httpRequestRepository, IRequestSenderService requestSenderService, IMapper mapper) : IHttpRequestService
    {
        private readonly IHttpRequestRepository httpRequestRepository = httpRequestRepository;
        private readonly IRequestSenderService requestSenderService = requestSenderService;
        private readonly IMapper mapper = mapper;

        public Guid AddHttpRequest(HttpRequestVm httpRequestVm)
        {
            var httpRequest = mapper;
            return Guid.NewGuid();
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
