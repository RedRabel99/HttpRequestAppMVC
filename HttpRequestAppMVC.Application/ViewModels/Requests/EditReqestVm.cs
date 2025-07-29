using AutoMapper;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.ViewModels.Requests;

public class EditReqestVm : IMapFrom<Request>
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Url { get; set; }
    public string Method { get; set; }
    public string? Body { get; set; }

    public Guid RequestListId { get; set; }
    public List<RequestHeaderVm> RequestHeaders { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Request, RequestVm>()
            .ForMember(
            dest => dest.RequestHeaders,
            opt => opt.MapFrom(
                src => src.RequestHeaders
                    .Select(
                        x => new RequestHeaderVm
                        {
                            Header = x.Header.Name,
                            Value = x.HeaderValue.Value,
                        })));

        profile.CreateMap<RequestVm, Request>()
            .ForMember(dest => dest.RequestHeaders,
                opt => opt.MapFrom(src => src.RequestHeaders.Select(x =>
                    new RequestHeader
                    {
                        Header = new Header { Name = x.Header },
                        HeaderValue = new HeaderValue { Value = x.Value }
                    }
                    )
                )
            );
    }
}
