using FluentValidation;
using FluentValidation.Results;
using HttpRequestAppMVC.Application.Interfaces.HttpRequest;
using HttpRequestAppMVC.Application.ViewModels.HttpRequests;
using HttpRequestAppMVC.Web.Helpers;
using Microsoft.AspNetCore.Mvc;


namespace HttpRequestAppMVC.Web.Controllers;

public class HttpRequestController(
    IHttpRequestService httpRequestService,
    IValidator<CreateHttpRequestVm> createVmValidator,
    IValidator<HttpRequestVm> editVmValidator) : Controller
{

    public IActionResult Index() { 
        return RedirectToAction(nameof(CreateHttpRequest));
    }

    [HttpGet]
    public IActionResult Details(Guid id)
    {
        var httpRequest = httpRequestService.GetHttpRequestById(id);
        return View(httpRequest);
    }

    [HttpGet]
    public IActionResult CreateHttpRequest()
    {

        var model = new CreateHttpRequestVm();
        model.HttpRequestHeaders.Add(
            new HttpRequestHeaderVm { Header = "content-type", Value = "xd" }
            );
        model.HttpRequestHeaders.Add(
            new HttpRequestHeaderVm { Header = "content-type2", Value = "xd" }
            );

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHttpRequest(CreateHttpRequestVm httpRequest)
    {
        ValidationResult result = createVmValidator.Validate(httpRequest);

        if (!result.IsValid)
        {
            result.AddToModelState(ModelState);
            return View(httpRequest);
        }

        if (httpRequest.SubmitAction == "send")
        {
            httpRequest.HttpResponse = await httpRequestService.SendHttpRequest(httpRequest);
            return View(httpRequest);
        }

        if(httpRequest.SubmitAction == "save")
        {
            var id = httpRequestService.AddHttpRequest(httpRequest);
            return RedirectToAction(nameof(Details), new {id});
        }
        return View(httpRequest);
    }
    [HttpGet]
    public IActionResult Edit(Guid id)
    {
        var httpRequest = httpRequestService.GetHttpRequestById(id);
        return View(httpRequest);
    }

    [HttpPost]
    public IActionResult Edit(HttpRequestVm httpRequest)
    {
        ValidationResult validationResult = editVmValidator.Validate(httpRequest);
        if (!validationResult.IsValid)
        {
            validationResult.AddToModelState(ModelState);
            return View(httpRequest);
        }

        Guid id = httpRequestService.UpdateHttpRequest(httpRequest);
        return RedirectToAction(nameof(Details), new { id });
    }

    [HttpPost]
    public IActionResult Delete(Guid id)
    {
        httpRequestService.RemoveHttpRequest(id);

        return View();
    }
}
