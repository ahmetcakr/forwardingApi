using Application.Features.Demurrages.Commands.Create;
using Application.Features.Demurrages.Commands.Delete;
using Application.Features.Demurrages.Commands.Update;
using Application.Features.Demurrages.Queries.GetById;
using Application.Features.Demurrages.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Demurrages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Demurrage, CreateDemurrageCommand>().ReverseMap();
        CreateMap<Demurrage, CreatedDemurrageResponse>().ReverseMap();
        CreateMap<Demurrage, UpdateDemurrageCommand>().ReverseMap();
        CreateMap<Demurrage, UpdatedDemurrageResponse>().ReverseMap();
        CreateMap<Demurrage, DeleteDemurrageCommand>().ReverseMap();
        CreateMap<Demurrage, DeletedDemurrageResponse>().ReverseMap();
        CreateMap<Demurrage, GetByIdDemurrageResponse>().ReverseMap();
        CreateMap<Demurrage, GetListDemurrageListItemDto>().ReverseMap();
        CreateMap<IPaginate<Demurrage>, GetListResponse<GetListDemurrageListItemDto>>().ReverseMap();
    }
}