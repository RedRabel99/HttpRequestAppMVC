using AutoMapper;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.ViewModels.RequestLists;

public class RequestForRequestListVm : IMapFrom<Request>
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Url {  get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Request, RequestForRequestListVm>();
    }
}
