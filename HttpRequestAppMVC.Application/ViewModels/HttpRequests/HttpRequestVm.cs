using AutoMapper;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace HttpRequestAppMVC.Application.ViewModels.HttpRequests;

public class HttpRequestVm : IMapFrom<HttpRequest>
{
    public string Url { get; set; } = string.Empty;
    public string Method { get; set; }
    public string Body { get; set; } = string.Empty;

    public List<HttpRequestHeaderVm> HttpRequestHeaders { get; set; } = new List<HttpRequestHeaderVm>();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<HttpRequest, HttpRequestVm>()
            .ForMember(
            dest => dest.HttpRequestHeaders,
            opt => opt.MapFrom(
                src => src.HttpRequestHeaders.ToDictionary(
                    x => x.HttpHeader, x => x.HttpHeaderValue)));

        //profile.CreateMap<HttpRequestVm, HttpRequest>()
        //    .ForMember(
        //    dest => dest.HttpRequestHeaders,
        //    opt => opt.MapFrom(
        //        src => src.HttpRequestHeaders.Select(rh => new Http()));
    }
}
