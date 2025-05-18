using AutoMapper;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;

public class HttpRequestForRequestListVm : IMapFrom<HttpRequest>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Url {  get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<HttpRequest, HttpRequestForRequestListVm>();
    }
}
