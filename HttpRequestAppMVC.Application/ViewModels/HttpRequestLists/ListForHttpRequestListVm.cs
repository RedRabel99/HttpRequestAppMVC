using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.ViewModels.HttpRequestLists
{
    public record ListForHttpRequestListVm
    {
        public List<HttpRequestListVm> HttpRequestLists { get; set; }
        public int Count { get; set; }

    }
}
