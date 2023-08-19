using Application.Features.Pols.Commands.Create;
using Application.Features.Pols.Commands.Delete;
using Application.Features.Pols.Commands.Update;
using Application.Features.Pols.Queries.GetById;
using Application.Features.Pols.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Pols.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pol, CreatePolCommand>().ReverseMap();
        CreateMap<Pol, CreatedPolResponse>().ReverseMap();
        CreateMap<Pol, UpdatePolCommand>().ReverseMap();
        CreateMap<Pol, UpdatedPolResponse>().ReverseMap();
        CreateMap<Pol, DeletePolCommand>().ReverseMap();
        CreateMap<Pol, DeletedPolResponse>().ReverseMap();
        CreateMap<Pol, GetByIdPolResponse>().ReverseMap();
        CreateMap<Pol, GetListPolListItemDto>().ReverseMap();
        CreateMap<IPaginate<Pol>, GetListResponse<GetListPolListItemDto>>().ReverseMap();
    }
}