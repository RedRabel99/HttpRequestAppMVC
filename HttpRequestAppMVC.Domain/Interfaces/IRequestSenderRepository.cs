using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Domain.Interfaces;

public interface IRequestSenderRepository
{
    public Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage request);
}
