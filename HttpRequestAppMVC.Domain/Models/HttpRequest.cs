using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Domain.Models
{
    public class HttpRequest : BaseEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Method { get; set; }
        public string? Body { get; set; }
        public Guid RequestListId { get; set; }
        public virtual HttpRequestList RequestList { get; set; }
        public virtual ICollection<RequestHeaderValue> HeaderValues { get; set; } = new List<RequestHeaderValue>();
        public virtual ICollection<HttpResponse> ResponseHistory { get; set; } = new List<HttpResponse>();

    }
}
