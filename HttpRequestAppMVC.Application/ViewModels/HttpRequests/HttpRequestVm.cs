using AutoMapper;
using FluentValidation;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;
using HttpRequestAppMVC.Domain.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace HttpRequestAppMVC.Application.ViewModels.HttpRequests;

public class HttpRequestVm : IMapFrom<HttpRequest>
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Url { get; set; } 
    public string Method { get; set; }
    public string? Body { get; set; }
    
    public Guid RequestListId { get; set; }
    public List<HttpRequestHeaderVm> HttpRequestHeaders { get; set; }
    public List<Guid> HeadersToDelete { get; set; } = new List<Guid>();

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
                            Id = x.Id,
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

public class EditHttpRequestVmValidator : AbstractValidator<HttpRequestVm>
{
    public EditHttpRequestVmValidator()
    {
        string[] methods = ["GET", "POST", "PUT", "DELETE", "PATCH"];
        RuleFor(r => r.Url).NotEmpty().MaximumLength(2048); //maximum acceptable size of urls
        RuleFor(r => r.Method).NotEmpty().Must(method => methods.Contains(method.ToUpperInvariant()));
        RuleFor(r => r.Name).NotEmpty().MaximumLength(100);
        RuleFor(r => r.RequestListId).NotNull();
    }
}
