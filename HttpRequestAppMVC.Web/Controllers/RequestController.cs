using FluentValidation;
using FluentValidation.Results;
using HttpRequestAppMVC.Application.Interfaces.Requests;
using HttpRequestAppMVC.Application.ViewModels.Requests;
using HttpRequestAppMVC.Web.Helpers;
using Microsoft.AspNetCore.Mvc;


namespace HttpRequestAppMVC.Web.Controllers;

public class RequestController(
    IRequestService requestService,
    IValidator<CreateRequestVm> createVmValidator,
    IValidator<RequestVm> editVmValidator) : Controller
{

    public IActionResult Index() { 
        return RedirectToAction(nameof(CreateRequest));
    }

    [HttpGet]
    public IActionResult Details(Guid id)
    {
        var request = requestService.GetRequestById(id);
        return View(request);
    }

    [HttpGet]
    public IActionResult CreateRequest()
    {

        var model = new CreateRequestVm();
        model.RequestHeaders.Add(
            new RequestHeaderVm { Header = "content-type", Value = "xd" }
            );
        model.RequestHeaders.Add(
            new RequestHeaderVm { Header = "content-type2", Value = "xd" }
            );

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRequest(CreateRequestVm request)
    {
        ValidationResult result = createVmValidator.Validate(request);

        if (!result.IsValid)
        {
            result.AddToModelState(ModelState);
            return View(request);
        }

        if (request.SubmitAction == "send")
        {
            request.Response = await requestService.SendRequest(request);
            return View(request);
        }

        if(request.SubmitAction == "save")
        {
            var id = requestService.AddRequest(request);
            return RedirectToAction(nameof(Details), new {id});
        }
        return View(request);
    }
    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        var request = requestService.GetRequestById(id);
        return View(request);
    }

    [HttpPost]
    public IActionResult Edit(RequestVm request)
    {
        ValidationResult validationResult = editVmValidator.Validate(request);
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(ModelState);
            return View(request);
        }

        Guid id = requestService.UpdateRequest(request);
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpPost]
    public IActionResult Delete(Guid id)
    {
        requestService.RemoveRequest(id);

        return View();
    }
}
