using AutoMapper;
using FluentValidation;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.ViewModels.Requests;

public class CreateRequestVm : IMapFrom<Request>
{
    public string Url { get; set; }
    public string Method { get; set; }
    public string? Body { get; set; }
    public List<RequestHeaderVm> RequestHeaders { get; set; } = new List<RequestHeaderVm>();
    public string? Name { get; set; }
    public Guid? RequestListId { get; set; }
    public string SubmitAction { get; set; }
    public RequestResponseVm? Response {  get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateRequestVm, Request>()
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

public class CreateRequestVmValidator : AbstractValidator<CreateRequestVm>
{
    public CreateRequestVmValidator()
    {
        string[] methods = ["GET", "POST", "PUT", "DELETE", "PATCH"];
        RuleFor(r => r.Url).NotEmpty().MaximumLength(2048); //maximum acceptable size of urls
        RuleFor(r => r.Method).NotEmpty().Must(method => methods.Contains(method.ToUpperInvariant()));
        RuleFor(r => r.Name).NotEmpty().MaximumLength(100).When(r => r.SubmitAction == "save");
        RuleFor(r => r.RequestListId).NotNull().When(r => r.SubmitAction == "save");
    }
}