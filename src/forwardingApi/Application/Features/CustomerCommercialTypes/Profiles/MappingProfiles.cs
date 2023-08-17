using Application.Features.CustomerCommercialTypes.Commands.Create;
using Application.Features.CustomerCommercialTypes.Commands.Delete;
using Application.Features.CustomerCommercialTypes.Commands.Update;
using Application.Features.CustomerCommercialTypes.Queries.GetById;
using Application.Features.CustomerCommercialTypes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CustomerCommercialTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerCommercialType, CreateCustomerCommercialTypeCommand>().ReverseMap();
        CreateMap<CustomerCommercialType, CreatedCustomerCommercialTypeResponse>().ReverseMap();
        CreateMap<CustomerCommercialType, UpdateCustomerCommercialTypeCommand>().ReverseMap();
        CreateMap<CustomerCommercialType, UpdatedCustomerCommercialTypeResponse>().ReverseMap();
        CreateMap<CustomerCommercialType, DeleteCustomerCommercialTypeCommand>().ReverseMap();
        CreateMap<CustomerCommercialType, DeletedCustomerCommercialTypeResponse>().ReverseMap();
        CreateMap<CustomerCommercialType, GetByIdCustomerCommercialTypeResponse>().ReverseMap();
        CreateMap<CustomerCommercialType, GetListCustomerCommercialTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomerCommercialType>, GetListResponse<GetListCustomerCommercialTypeListItemDto>>().ReverseMap();
    }
}