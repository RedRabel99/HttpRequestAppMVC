using HttpRequestAppMVC.Application.Interfaces.HttpRequest;
using HttpRequestAppMVC.Application.ViewModels.HttpRequests;
using Microsoft.AspNetCore.Mvc;

namespace HttpRequestAppMVC.Web.Controllers
{
    public class HttpRequestController(IHttpRequestService httpRequestService) : Controller
    {

        public IActionResult Index() { 
            return View();
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
            var model = new NewHttpRequestVm { HttpRequest = new HttpRequestVm() };
            model.HttpRequest.HttpRequestHeaders.Add(
                new HttpRequestHeaderVm { Header = "content-type", Value="xd"}
                );
            model.HttpRequest.HttpRequestHeaders.Add(
                new HttpRequestHeaderVm { Header = "content-type2", Value = "xd" }
                );

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> NewHttpRequest(NewHttpRequestVm newHttpRequest)
        {
            if (!ModelState.IsValid) 
            {
                return View(newHttpRequest); 
            }

            if (newHttpRequest.SubmitAction == "send")
            {
                newHttpRequest.HttpResponse = await httpRequestService.SendHttpRequest(newHttpRequest.HttpRequest);
                return View(newHttpRequest);
            }

            if(newHttpRequest.SubmitAction == "save")
            {
                var id = httpRequestService.AddHttpRequest(newHttpRequest.HttpRequest);
                return RedirectToAction(nameof(Details), new {id});
            }
            return View(newHttpRequest);
        }
    }
}
