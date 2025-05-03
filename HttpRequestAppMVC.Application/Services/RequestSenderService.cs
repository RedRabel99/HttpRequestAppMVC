using HttpRequestAppMVC.Application.Interfaces;
using HttpRequestAppMVC.Application.ViewModels.HttpRequests;
using HttpRequestAppMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.Services;

public class RequestSenderService(IRequestSenderRepository requestSenderRepository) : IRequestSenderService
{
    private readonly IRequestSenderRepository requestSenderRepository = requestSenderRepository;

    public async Task<NewRequestVm> SendRequest(NewRequestVm model)
    {
        var request = new HttpRequestMessage(new HttpMethod(model.Method), model.Url);

        if (!string.IsNullOrEmpty(model.Body) && (model.Method == "POST" || model.Method == "PUT"))
        {
            request.Content = new StringContent(model.Body, Encoding.UTF8, "application/json");
        }
        var response = await requestSenderRepository.SendRequestAsync(request);
        model.ResponseStatusCode = (int)response.StatusCode;
        model.ResponseBody = response.Content.ReadAsStringAsync().Result;
        return model;
    }
}
