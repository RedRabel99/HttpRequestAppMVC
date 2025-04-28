using HttpRequestAppMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Infrastructure.Repositories;

public class RequestSenderRepository : IRequestSenderRepository
{
    private readonly HttpClient httpClient;
    public RequestSenderRepository()
    {
        httpClient = new HttpClient();
    }
    public async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request)
    {
        return await httpClient.SendAsync(request);
    }
}
