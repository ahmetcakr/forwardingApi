using Application.Features.Ships.Commands.Create;
using Application.Features.Ships.Commands.Delete;
using Application.Features.Ships.Commands.Update;
using Application.Features.Ships.Queries.GetById;
using Application.Features.Ships.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Ships.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Ship, CreateShipCommand>().ReverseMap();
        CreateMap<Ship, CreatedShipResponse>().ReverseMap();
        CreateMap<Ship, UpdateShipCommand>().ReverseMap();
        CreateMap<Ship, UpdatedShipResponse>().ReverseMap();
        CreateMap<Ship, DeleteShipCommand>().ReverseMap();
        CreateMap<Ship, DeletedShipResponse>().ReverseMap();
        CreateMap<Ship, GetByIdShipResponse>().ReverseMap();
        CreateMap<Ship, GetListShipListItemDto>().ReverseMap();
        CreateMap<IPaginate<Ship>, GetListResponse<GetListShipListItemDto>>().ReverseMap();
    }
}