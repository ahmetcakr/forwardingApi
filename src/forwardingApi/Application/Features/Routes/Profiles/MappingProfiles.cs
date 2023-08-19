using Application.Features.Routes.Commands.Create;
using Application.Features.Routes.Commands.Delete;
using Application.Features.Routes.Commands.Update;
using Application.Features.Routes.Queries.GetById;
using Application.Features.Routes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Routes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Route, CreateRouteCommand>().ReverseMap();
        CreateMap<Route, CreatedRouteResponse>().ReverseMap();
        CreateMap<Route, UpdateRouteCommand>().ReverseMap();
        CreateMap<Route, UpdatedRouteResponse>().ReverseMap();
        CreateMap<Route, DeleteRouteCommand>().ReverseMap();
        CreateMap<Route, DeletedRouteResponse>().ReverseMap();
        CreateMap<Route, GetByIdRouteResponse>().ReverseMap();
        CreateMap<Route, GetListRouteListItemDto>().ReverseMap();
        CreateMap<IPaginate<Route>, GetListResponse<GetListRouteListItemDto>>().ReverseMap();
    }
}