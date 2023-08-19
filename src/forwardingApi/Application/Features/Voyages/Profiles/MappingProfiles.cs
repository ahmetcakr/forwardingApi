using Application.Features.Voyages.Commands.Create;
using Application.Features.Voyages.Commands.Delete;
using Application.Features.Voyages.Commands.Update;
using Application.Features.Voyages.Queries.GetById;
using Application.Features.Voyages.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Voyages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Voyage, CreateVoyageCommand>().ReverseMap();
        CreateMap<Voyage, CreatedVoyageResponse>().ReverseMap();
        CreateMap<Voyage, UpdateVoyageCommand>().ReverseMap();
        CreateMap<Voyage, UpdatedVoyageResponse>().ReverseMap();
        CreateMap<Voyage, DeleteVoyageCommand>().ReverseMap();
        CreateMap<Voyage, DeletedVoyageResponse>().ReverseMap();
        CreateMap<Voyage, GetByIdVoyageResponse>().ReverseMap();
        CreateMap<Voyage, GetListVoyageListItemDto>().ReverseMap();
        CreateMap<IPaginate<Voyage>, GetListResponse<GetListVoyageListItemDto>>().ReverseMap();
    }
}