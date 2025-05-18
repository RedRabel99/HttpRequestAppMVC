using AutoMapper;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;

public class HttpRequestListVm : IMapFrom<HttpRequestList>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [ValidateNever]
    public IEnumerable<HttpRequestForRequestListVm> HttpRequests { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<HttpRequestList, HttpRequestListVm>()
            .ForMember(dest => dest.HttpRequests, opt => opt.MapFrom(src => src.HttpRequests));

        profile.CreateMap<HttpRequestListVm, HttpRequestList>()
            .ForMember(dest => dest.HttpRequests, opt => opt.Ignore());
    }
}
