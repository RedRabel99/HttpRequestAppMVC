using AutoMapper;
using FluentValidation;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Application.ViewModels.RequestLists;
using HttpRequestAppMVC.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HttpRequestAppMVC.Application.ViewModels.Requests;

public class RequestVm : IMapFrom<Request>
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Url { get; set; } 
    public string Method { get; set; }
    public string? Body { get; set; }
    
    public Guid RequestListId { get; set; }
    public List<RequestHeaderVm> RequestHeaders { get; set; }
    public List<Guid> HeadersToDelete { get; set; } = new List<Guid>();

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
                            Id = x.Id,
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

public class EditRequestVmValidator : AbstractValidator<RequestVm>
{
    public EditRequestVmValidator()
    {
        string[] methods = ["GET", "POST", "PUT", "DELETE", "PATCH"];
        RuleFor(r => r.Url).NotEmpty().MaximumLength(2048); //maximum acceptable size of urls
        RuleFor(r => r.Method).NotEmpty().Must(method => methods.Contains(method.ToUpperInvariant()));
        RuleFor(r => r.Name).NotEmpty().MaximumLength(100);
        RuleFor(r => r.RequestListId).NotNull();
    }
}
