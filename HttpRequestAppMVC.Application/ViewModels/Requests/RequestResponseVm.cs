namespace HttpRequestAppMVC.Application.ViewModels.Requests
{
    public class RequestResponseVm
    {
        public int StatusCode { get; set; }
        public string ResponseMessage { get; set; } = string.Empty;
    }
}