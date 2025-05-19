using AutoMapper;
using FluentValidation;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.ViewModels.HttpRequests;

public class CreateHttpRequestVm : IMapFrom<HttpRequest>
{
    public string Url { get; set; }
    public string Method { get; set; }
    public string? Body { get; set; }
    public List<HttpRequestHeaderVm> HttpRequestHeaders { get; set; } = new List<HttpRequestHeaderVm>();
    public string? Name { get; set; }
    public Guid? RequestListId { get; set; }
    public string SubmitAction { get; set; }
    public HttpRequestResponseVm? HttpResponse {  get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateHttpRequestVm, HttpRequest>()
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

public class CreateHttpRequestVmValidator : AbstractValidator<CreateHttpRequestVm>
{
    public CreateHttpRequestVmValidator()
    {
        string[] methods = ["GET", "POST", "PUT", "DELETE", "PATCH"];
        RuleFor(r => r.Url).NotEmpty().MaximumLength(2048); //maximum acceptable size of urls
        RuleFor(r => r.Method).NotEmpty().Must(method => methods.Contains(method.ToUpperInvariant()));
        RuleFor(r => r.Name).NotEmpty().MaximumLength(100).When(r => r.SubmitAction == "save");
        RuleFor(r => r.RequestListId).NotNull().When(r => r.SubmitAction == "save");
    }
}