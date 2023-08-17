using Application.Features.CustomerFirmTypes.Commands.Create;
using Application.Features.CustomerFirmTypes.Commands.Delete;
using Application.Features.CustomerFirmTypes.Commands.Update;
using Application.Features.CustomerFirmTypes.Queries.GetById;
using Application.Features.CustomerFirmTypes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CustomerFirmTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerFirmType, CreateCustomerFirmTypeCommand>().ReverseMap();
        CreateMap<CustomerFirmType, CreatedCustomerFirmTypeResponse>().ReverseMap();
        CreateMap<CustomerFirmType, UpdateCustomerFirmTypeCommand>().ReverseMap();
        CreateMap<CustomerFirmType, UpdatedCustomerFirmTypeResponse>().ReverseMap();
        CreateMap<CustomerFirmType, DeleteCustomerFirmTypeCommand>().ReverseMap();
        CreateMap<CustomerFirmType, DeletedCustomerFirmTypeResponse>().ReverseMap();
        CreateMap<CustomerFirmType, GetByIdCustomerFirmTypeResponse>().ReverseMap();
        CreateMap<CustomerFirmType, GetListCustomerFirmTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomerFirmType>, GetListResponse<GetListCustomerFirmTypeListItemDto>>().ReverseMap();
    }
}