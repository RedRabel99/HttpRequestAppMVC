using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.ViewModels.HttpRequests
{
    public class HttpRequestHeaderVm
    {
        public Guid Id { get; set; }
        public string Header {  get; set; }
        public string Value { get; set; }
    }
}
