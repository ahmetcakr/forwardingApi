using Application.Features.Sectors.Commands.Create;
using Application.Features.Sectors.Commands.Delete;
using Application.Features.Sectors.Commands.Update;
using Application.Features.Sectors.Queries.GetById;
using Application.Features.Sectors.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Sectors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Sector, CreateSectorCommand>().ReverseMap();
        CreateMap<Sector, CreatedSectorResponse>().ReverseMap();
        CreateMap<Sector, UpdateSectorCommand>().ReverseMap();
        CreateMap<Sector, UpdatedSectorResponse>().ReverseMap();
        CreateMap<Sector, DeleteSectorCommand>().ReverseMap();
        CreateMap<Sector, DeletedSectorResponse>().ReverseMap();
        CreateMap<Sector, GetByIdSectorResponse>().ReverseMap();
        CreateMap<Sector, GetListSectorListItemDto>().ReverseMap();
        CreateMap<IPaginate<Sector>, GetListResponse<GetListSectorListItemDto>>().ReverseMap();
    }
}