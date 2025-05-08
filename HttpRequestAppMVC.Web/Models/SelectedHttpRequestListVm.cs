using HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;

namespace HttpRequestAppMVC.Web.Models;

public class SelectedHttpRequestListVm
{
    public IEnumerable<HttpRequestListVm> RequestLists { get; set; }
    public Guid SelectedRequestListId {  get; set; }
}
