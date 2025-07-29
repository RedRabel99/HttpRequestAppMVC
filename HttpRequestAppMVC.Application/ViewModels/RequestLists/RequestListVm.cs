using AutoMapper;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HttpRequestAppMVC.Application.ViewModels.RequestLists;

public class RequestListVm : IMapFrom<RequestList>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [ValidateNever]
    public IEnumerable<RequestForRequestListVm> Requests { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<RequestList, RequestListVm>()
            .ForMember(dest => dest.Requests, opt => opt.MapFrom(src => src.Requests));

        profile.CreateMap<RequestListVm, RequestList>()
            .ForMember(dest => dest.Requests, opt => opt.Ignore());
    }
}
