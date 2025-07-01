using AutoMapper;

namespace HttpRequestAppMVC.Application.Mapping;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}
