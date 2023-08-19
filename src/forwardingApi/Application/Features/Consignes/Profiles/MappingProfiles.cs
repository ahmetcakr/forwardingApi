using Application.Features.Consignes.Commands.Create;
using Application.Features.Consignes.Commands.Delete;
using Application.Features.Consignes.Commands.Update;
using Application.Features.Consignes.Queries.GetById;
using Application.Features.Consignes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Consignes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Consigne, CreateConsigneCommand>().ReverseMap();
        CreateMap<Consigne, CreatedConsigneResponse>().ReverseMap();
        CreateMap<Consigne, UpdateConsigneCommand>().ReverseMap();
        CreateMap<Consigne, UpdatedConsigneResponse>().ReverseMap();
        CreateMap<Consigne, DeleteConsigneCommand>().ReverseMap();
        CreateMap<Consigne, DeletedConsigneResponse>().ReverseMap();
        CreateMap<Consigne, GetByIdConsigneResponse>().ReverseMap();
        CreateMap<Consigne, GetListConsigneListItemDto>().ReverseMap();
        CreateMap<IPaginate<Consigne>, GetListResponse<GetListConsigneListItemDto>>().ReverseMap();
    }
}