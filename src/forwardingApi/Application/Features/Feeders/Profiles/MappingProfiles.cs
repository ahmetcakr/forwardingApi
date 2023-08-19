using Application.Features.Feeders.Commands.Create;
using Application.Features.Feeders.Commands.Delete;
using Application.Features.Feeders.Commands.Update;
using Application.Features.Feeders.Queries.GetById;
using Application.Features.Feeders.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Feeders.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Feeder, CreateFeederCommand>().ReverseMap();
        CreateMap<Feeder, CreatedFeederResponse>().ReverseMap();
        CreateMap<Feeder, UpdateFeederCommand>().ReverseMap();
        CreateMap<Feeder, UpdatedFeederResponse>().ReverseMap();
        CreateMap<Feeder, DeleteFeederCommand>().ReverseMap();
        CreateMap<Feeder, DeletedFeederResponse>().ReverseMap();
        CreateMap<Feeder, GetByIdFeederResponse>().ReverseMap();
        CreateMap<Feeder, GetListFeederListItemDto>().ReverseMap();
        CreateMap<IPaginate<Feeder>, GetListResponse<GetListFeederListItemDto>>().ReverseMap();
    }
}