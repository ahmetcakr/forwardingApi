using Application.Features.CommercialTypes.Commands.Create;
using Application.Features.CommercialTypes.Commands.Delete;
using Application.Features.CommercialTypes.Commands.Update;
using Application.Features.CommercialTypes.Queries.GetById;
using Application.Features.CommercialTypes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CommercialTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CommercialType, CreateCommercialTypeCommand>().ReverseMap();
        CreateMap<CommercialType, CreatedCommercialTypeResponse>().ReverseMap();
        CreateMap<CommercialType, UpdateCommercialTypeCommand>().ReverseMap();
        CreateMap<CommercialType, UpdatedCommercialTypeResponse>().ReverseMap();
        CreateMap<CommercialType, DeleteCommercialTypeCommand>().ReverseMap();
        CreateMap<CommercialType, DeletedCommercialTypeResponse>().ReverseMap();
        CreateMap<CommercialType, GetByIdCommercialTypeResponse>().ReverseMap();
        CreateMap<CommercialType, GetListCommercialTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<CommercialType>, GetListResponse<GetListCommercialTypeListItemDto>>().ReverseMap();
    }
}