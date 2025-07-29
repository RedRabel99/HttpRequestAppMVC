namespace HttpRequestAppMVC.Application.ViewModels.Requests;

public class NewRequestVm
{
    public RequestVm Request {  get; set; }
    public RequestResponseVm? Response { get; set; } = null;
    public string SubmitAction { get; set; } = string.Empty;
}
