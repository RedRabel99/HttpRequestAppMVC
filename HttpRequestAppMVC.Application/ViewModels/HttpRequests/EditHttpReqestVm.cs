using AutoMapper;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.ViewModels.HttpRequests;

public class EditHttpReqestVm : IMapFrom<HttpRequest>
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Method { get; set; }
    public string? Body { get; set; }

    public Guid RequestListId { get; set; }
    public List<HttpRequestHeaderVm> HttpRequestHeaders { get; set; }

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
