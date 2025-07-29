using HttpRequestAppMVC.Domain.Interfaces;

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
