using AutoMapper;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;

public class CreateHttpRequestListVm : IMapFrom<HttpRequestList>
{
    public string Name { get; set; }
    public string Description { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateHttpRequestListVm, HttpRequestList>();
    }
}
