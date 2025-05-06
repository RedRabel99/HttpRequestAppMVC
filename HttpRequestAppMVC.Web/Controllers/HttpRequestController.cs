using HttpRequestAppMVC.Application.Interfaces;
using HttpRequestAppMVC.Application.ViewModels.HttpRequests;
using Microsoft.AspNetCore.Mvc;

namespace HttpRequestAppMVC.Web.Controllers
{
    public class HttpRequestController(IHttpRequestService httpRequestService) : Controller
    {
        private readonly IHttpRequestService httpRequestService = httpRequestService;

        public IActionResult Index() { 
            return View();
        }
        [HttpGet]
        public IActionResult NewHttpRequest()
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
        public async Task<IActionResult> NewHttpRequest(NewHttpRequestVm newHttpRequest, string action)
        {
            if (!ModelState.IsValid)
            {
                return View(newHttpRequest);
            }

            if (action == "send")
            {
                newHttpRequest.HttpResponse = await httpRequestService.SendHttpRequest(newHttpRequest.HttpRequest);
                return View(newHttpRequest);
            }

            if(action == "save")
            {
                var id = httpRequestService.AddHttpRequest(newHttpRequest.HttpRequest);
                return RedirectToAction("Details", id);
            }
            return View(newHttpRequest);
        }
    }
}
