using AutoMapper;
using FluentValidation;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.ViewModels.HttpRequestLists;

public class CreateHttpRequestListVm : IMapFrom<HttpRequestList>
{
    public string Name { get; set; }
    private string description;
    public string? Description {
        get => description;
        set => description = value ?? string.Empty;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateHttpRequestListVm, HttpRequestList>();
    }
}

public class CreateHttpRequestListVmValidator : AbstractValidator<CreateHttpRequestListVm>
{
    public CreateHttpRequestListVmValidator()
    {  
        RuleFor(requestList => requestList.Name).NotEmpty().MaximumLength(30);
        RuleFor(requestList => requestList.Description).NotNull().MaximumLength(10);
    }
}
