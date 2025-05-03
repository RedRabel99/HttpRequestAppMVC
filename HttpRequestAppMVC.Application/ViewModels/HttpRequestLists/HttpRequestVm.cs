using AutoMapper;
using HttpRequestAppMVC.Application.Mapping;
using HttpRequestAppMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpRequestAppMVC.Application.ViewModels.HttpRequestLists
{
    public record HttpRequestVm : IMapFrom<HttpRequestList>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<HttpRequestVm, HttpRequestList>()
                .ReverseMap();
        }
    }
}
