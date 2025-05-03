using HttpRequestAppMVC.Application.Interfaces;
using HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;
using HttpRequestAppMVC.Application.ViewModels.HttpRequests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HttpRequestAppMVC.Web.Controllers
{
    public class RequestController(
        IRequestSenderService requestSenderService,
        IHttpRequestService httpRequestService
        ) : Controller
    {
        private readonly IRequestSenderService requestSenderService =  requestSenderService;
        private readonly IHttpRequestService httpRequestService = httpRequestService;

        [HttpGet]
        public IActionResult SendRequest()
        {
            return View(new NewRequestVm());
        }

        [HttpPost]
        public async Task<IActionResult> SendRequest(NewRequestVm model)
        {
            if (!ModelState.IsValid)
                return View(model);
            
            model = await requestSenderService.SendRequest(model);

            return View(model);
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = httpRequestService.GetAllRequestLists();
            return View(model);
        }

        [HttpGet]
        public IActionResult AddRequestList()
        {
            return View(new HttpRequestVm());
        }

        [HttpPost]
        public IActionResult AddRequestList(HttpRequestVm model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var id = httpRequestService.AddRequestList(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditRequestList(Guid id)
        {
            var requestList = httpRequestService.GetRequestListById(id);
            return View(requestList);
        }

        [HttpPost]
        public IActionResult EditRequestList(HttpRequestVm model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var id = httpRequestService.EditRequestList(model);
            return RedirectToAction("Index");
        }
    }
}
