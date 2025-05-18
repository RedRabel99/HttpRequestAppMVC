using AutoMapper;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;
using HttpRequestAppMVC.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HttpRequestAppMVC.Application.ViewModels.HttpRequests;

public class HttpRequestVm : IMapFrom<HttpRequest>
{
    public Guid Id { get; set; }
    [ValidateNever]
    public string Name { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Method { get; set; }
    public string Body { get; set; } = string.Empty;
    [ValidateNever]
    public string RequestListId { get; set; }
    [ValidateNever]
    public HttpRequestListVm HttpRequestList {  get; set; }
    public List<HttpRequestHeaderVm> HttpRequestHeaders { get; set; } = new List<HttpRequestHeaderVm>();

    public void Mapping(Profile profile)
    {
        profile.CreateMap<HttpRequest, HttpRequestVm>()
            .ForMember(
            dest => dest.HttpRequestHeaders,
            opt => opt.MapFrom(
                src => src.HttpRequestHeaders
                    .Select(
                        x => new HttpRequestHeaderVm
                        {
                            Header = x.HttpHeader.Name,
                            Value = x.HttpHeaderValue.Value,
                        })));
        profile.CreateMap<HttpRequestVm, HttpRequest>()
            .ForMember(dest => dest.HttpRequestHeaders,
                opt => opt.MapFrom(src => src.HttpRequestHeaders.Select(x =>
                    new HttpRequestHeader
                    {
                        HttpHeader = new HttpHeader { Name = x.Header },
                        HttpHeaderValue = new HttpHeaderValue { Value = x.Value }
                    }
                    )
                )
            );
    }
}
