using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.ViewModels.Requests
{
    public class RequestHeaderVm
    {
        public Guid Id { get; set; }
        public string Header {  get; set; }
        public string Value { get; set; }
    }
}
