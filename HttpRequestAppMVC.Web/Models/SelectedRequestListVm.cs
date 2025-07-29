using HttpRequestAppMVC.Application.ViewModels.RequestLists;

namespace HttpRequestAppMVC.Web.Models;

public class SelectedRequestListVm
{
    public IEnumerable<RequestListVm> RequestLists { get; set; }
    public Guid SelectedRequestListId {  get; set; }
}
