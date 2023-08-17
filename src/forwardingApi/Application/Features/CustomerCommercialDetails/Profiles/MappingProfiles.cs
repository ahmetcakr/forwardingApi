using Application.Features.CustomerCommercialDetails.Commands.Create;
using Application.Features.CustomerCommercialDetails.Commands.Delete;
using Application.Features.CustomerCommercialDetails.Commands.Update;
using Application.Features.CustomerCommercialDetails.Queries.GetById;
using Application.Features.CustomerCommercialDetails.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CustomerCommercialDetails.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerCommercialDetail, CreateCustomerCommercialDetailCommand>().ReverseMap();
        CreateMap<CustomerCommercialDetail, CreatedCustomerCommercialDetailResponse>().ReverseMap();
        CreateMap<CustomerCommercialDetail, UpdateCustomerCommercialDetailCommand>().ReverseMap();
        CreateMap<CustomerCommercialDetail, UpdatedCustomerCommercialDetailResponse>().ReverseMap();
        CreateMap<CustomerCommercialDetail, DeleteCustomerCommercialDetailCommand>().ReverseMap();
        CreateMap<CustomerCommercialDetail, DeletedCustomerCommercialDetailResponse>().ReverseMap();
        CreateMap<CustomerCommercialDetail, GetByIdCustomerCommercialDetailResponse>().ReverseMap();
        CreateMap<CustomerCommercialDetail, GetListCustomerCommercialDetailListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomerCommercialDetail>, GetListResponse<GetListCustomerCommercialDetailListItemDto>>().ReverseMap();
    }
}