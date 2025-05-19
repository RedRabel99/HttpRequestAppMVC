using HttpRequestAppMVC.Application.Interfaces.HttpRequest;
using HttpRequestAppMVC.Application.ViewModels.HttpRequests;
using HttpRequestAppMVC.Domain.Interfaces;
using System.Text;

namespace HttpRequestAppMVC.Application.Services.HttpRequestServices;

public class RequestSenderService(IRequestSenderRepository requestSenderRepository) : IRequestSenderService
{
    private readonly IRequestSenderRepository requestSenderRepository = requestSenderRepository;

    //public async Task<HttpRequestVm> SendRequest(HttpRequestVm model)
    //{
    //    var request = new HttpRequestMessage(new HttpMethod(model.Method), model.Url);

    //    if (!string.IsNullOrEmpty(model.Body) && (model.Method == "POST" || model.Method == "PUT"))
    //    {
    //        request.Content = new StringContent(model.Body, Encoding.UTF8, "application/json");
    //    }
    //    var response = await requestSenderRepository.SendRequestAsync(request);
    //    //model.ResponseStatusCode = (int)response.StatusCode;
    //    //model.ResponseBody = response.Content.ReadAsStringAsync().Result;
    //    return model;
    //}

    public async Task<HttpRequestResponseVm> SendRequest(CreateHttpRequestVm model)
    {
        var request = new HttpRequestMessage(new HttpMethod(model.Method), model.Url);
        if (!string.IsNullOrEmpty(model.Body) && (model.Method == "POST" || model.Method == "PUT"))
        {
            request.Content = new StringContent(model.Body, Encoding.UTF8, "application/json");
        }
        var response = await requestSenderRepository.SendRequestAsync(request);

        return new HttpRequestResponseVm
        {
            StatusCode = (int)response.StatusCode,
            ResponseMessage = response.Content.ReadAsStringAsync().Result
        };
    }
}
