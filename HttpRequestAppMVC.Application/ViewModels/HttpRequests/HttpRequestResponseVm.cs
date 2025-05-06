namespace HttpRequestAppMVC.Application.ViewModels.HttpRequests
{
    public class HttpRequestResponseVm
    {
        public int StatusCode { get; set; }
        public string ResponseMessage { get; set; } = string.Empty;
    }
}