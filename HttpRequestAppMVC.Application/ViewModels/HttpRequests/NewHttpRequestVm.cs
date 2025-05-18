namespace HttpRequestAppMVC.Application.ViewModels.HttpRequests;

public class NewHttpRequestVm
{
    public HttpRequestVm HttpRequest {  get; set; }
    public HttpRequestResponseVm? HttpResponse { get; set; } = null;
    public string SubmitAction { get; set; } = string.Empty;
}
