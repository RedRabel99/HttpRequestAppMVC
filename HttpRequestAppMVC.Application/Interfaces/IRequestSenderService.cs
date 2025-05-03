using HttpRequestAppMVC.Application.ViewModels.HttpRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.Interfaces;

public interface IRequestSenderService
{
    public Task<NewRequestVm> SendRequest(NewRequestVm model);
}
