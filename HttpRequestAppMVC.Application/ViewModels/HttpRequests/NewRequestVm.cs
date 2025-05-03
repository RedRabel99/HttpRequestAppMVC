using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HttpRequestAppMVC.Application.ViewModels.HttpRequests;

public class NewRequestVm
{
    public string Url { get; set; } = string.Empty;
    public string Method { get; set; }
    public string Body { get; set; } = string.Empty;

    public int? ResponseStatusCode { get; set; }
    public string? ResponseBody { get; set; } = string.Empty;

}
