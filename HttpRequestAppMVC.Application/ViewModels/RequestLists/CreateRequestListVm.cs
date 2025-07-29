using AutoMapper;
using FluentValidation;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Domain.Models;

namespace HttpRequestAppMVC.Application.ViewModels.RequestLists;

public class CreateRequestListVm : IMapFrom<RequestList>
{
    public string Name { get; set; }
    private string description;
    public string? Description {
        get => description;
        set => description = value ?? string.Empty;
    }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateRequestListVm, RequestList>();
    }
}

public class CreateRequestListVmValidator : AbstractValidator<CreateRequestListVm>
{
    public CreateRequestListVmValidator()
    {  
        RuleFor(requestList => requestList.Name).NotEmpty().MaximumLength(30);
        RuleFor(requestList => requestList.Description).NotNull().MaximumLength(10);
    }
}
