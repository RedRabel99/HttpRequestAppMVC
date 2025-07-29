using FluentValidation;
using FluentValidation.Results;
using HttpRequestAppMVC.Application.Interfaces.RequestLists;
using HttpRequestAppMVC.Application.ViewModels.RequestLists;
using HttpRequestAppMVC.Web.Helpers;
using HttpRequestAppMVC.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HttpRequestAppMVC.Web.Controllers;

public class RequestListController(
    IRequestListService requestListService,
    IValidator<CreateRequestListVm> validator) : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var model = requestListService.GetAllRequestLists();
        return View(model);
    }

    [HttpGet]
    public IActionResult Details(Guid id)
    {
        var model = requestListService.GetRequestListById(id);
        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    //[FormValidator]
    public IActionResult Create(CreateRequestListVm model)
    {
        ValidationResult result = validator.Validate(model);
        if (!result.IsValid)
        {
            result.AddToModelState(ModelState);
            return View(model);
        }
        var id = requestListService.CreateRequestList(model);
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        var model = requestListService.GetRequestListById(id);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(RequestListVm model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var id = requestListService.EditRequestList(model);
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpDelete]
    public IActionResult Delete(Guid id)
    {
        requestListService.DeleteRequestList(id);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult CreateSelectedRequestList()
    {
        var ListForRequestList = requestListService.GetAllRequestLists();
        var model = new SelectedRequestListVm
        {
            RequestLists = ListForRequestList.RequestLists,
            SelectedRequestListId = Guid.Empty
        };

        return PartialView("_CreateSelectedRequestList", model);
    }

    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult CreateSelectedRequestList(SelectedRequestListVm model)
    {
        if (!ModelState.IsValid)
        {
            return PartialView("_CreateSelectedRequestList", model);
        }

        return View(model);
    }
}