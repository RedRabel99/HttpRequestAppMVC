using HttpRequestAppMVC.Application.Interfaces;
using HttpRequestAppMVC.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace HttpRequestAppMVC.Web.Controllers
{
    public class RequestController(IRequestSenderService requestSenderService) : Controller
    {
        private readonly IRequestSenderService requestSenderService =  requestSenderService;
        [HttpGet]
        public IActionResult Index(NewRequestVm model)
        {
            return View(model);
        }

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
    }
}
