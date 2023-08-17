using Application.Features.CommercialDetails.Commands.Create;
using Application.Features.CommercialDetails.Commands.Delete;
using Application.Features.CommercialDetails.Commands.Update;
using Application.Features.CommercialDetails.Queries.GetById;
using Application.Features.CommercialDetails.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CommercialDetails.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CommercialDetail, CreateCommercialDetailCommand>().ReverseMap();
        CreateMap<CommercialDetail, CreatedCommercialDetailResponse>().ReverseMap();
        CreateMap<CommercialDetail, UpdateCommercialDetailCommand>().ReverseMap();
        CreateMap<CommercialDetail, UpdatedCommercialDetailResponse>().ReverseMap();
        CreateMap<CommercialDetail, DeleteCommercialDetailCommand>().ReverseMap();
        CreateMap<CommercialDetail, DeletedCommercialDetailResponse>().ReverseMap();
        CreateMap<CommercialDetail, GetByIdCommercialDetailResponse>().ReverseMap();
        CreateMap<CommercialDetail, GetListCommercialDetailListItemDto>().ReverseMap();
        CreateMap<IPaginate<CommercialDetail>, GetListResponse<GetListCommercialDetailListItemDto>>().ReverseMap();
    }
}