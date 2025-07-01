using HttpRequestAppMVC.Application.Interfaces.HttpRequestList;
using HttpRequestAppMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HttpRequestAppMVC.Web.ViewComponents;

public class RequestListSelectorViewComponent(IHttpRequestListService httpRequestListService) : ViewComponent
{
    public IViewComponentResult Invoke(Guid? requestListId)
    {
        var model = new SelectedHttpRequestListVm
        {
            RequestLists = httpRequestListService.GetAllHttpRequestLists().HttpRequestLists,
            SelectedRequestListId = requestListId ?? Guid.Empty
        };

        return View(model);
    }
}
