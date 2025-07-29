using HttpRequestAppMVC.Application.Interfaces.RequestLists;
using HttpRequestAppMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HttpRequestAppMVC.Web.ViewComponents;

public class RequestListSelectorViewComponent(IRequestListService requestListService) : ViewComponent
{
    public IViewComponentResult Invoke(Guid? requestListId)
    {
        var model = new SelectedRequestListVm
        {
            RequestLists = requestListService.GetAllRequestLists().RequestLists,
            SelectedRequestListId = requestListId ?? Guid.Empty
        };

        return View(model);
    }
}
