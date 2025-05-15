using HttpRequestAppMVC.Application.Interfaces.HttpRequestList;
using HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;
using HttpRequestAppMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HttpRequestAppMVC.Web.Controllers;

public class HttpRequestListController(IHttpRequestListService httpRequestListService) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var model = httpRequestListService.GetAllHttpRequestLists();
        return View(model);
    }

    [HttpGet]
    public IActionResult Details(Guid id)
    {
        var model = httpRequestListService.GetHttpRequestListById(id);
        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(CreateHttpRequestListVm model)
    {
        if (!ModelState.IsValid)
            return View(model);
        var id = httpRequestListService.CreateHttpRequestList(model);
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        var model = httpRequestListService.GetHttpRequestListById(id);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(HttpRequestListVm model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var id = httpRequestListService.EditRequestList(model);
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        httpRequestListService.DeleteRequestList(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult CreateSelectedRequestList()
    {
        var ListForHttpRequestList = httpRequestListService.GetAllHttpRequestLists();
        var model = new SelectedHttpRequestListVm
        {
            RequestLists = ListForHttpRequestList.HttpRequestLists,
            SelectedRequestListId = Guid.Empty
        };

        return PartialView("_CreateSelectedRequestList", model);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult CreateSelectedRequestList(SelectedHttpRequestListVm model)
    {
        if (!ModelState.IsValid)
        {
            return PartialView("_CreateSelectedRequestList", model);
        }

        return View(model);
    }
}