using Application.Features.CustomerSectors.Commands.Create;
using Application.Features.CustomerSectors.Commands.Delete;
using Application.Features.CustomerSectors.Commands.Update;
using Application.Features.CustomerSectors.Queries.GetById;
using Application.Features.CustomerSectors.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CustomerSectors.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerSector, CreateCustomerSectorCommand>().ReverseMap();
        CreateMap<CustomerSector, CreatedCustomerSectorResponse>().ReverseMap();
        CreateMap<CustomerSector, UpdateCustomerSectorCommand>().ReverseMap();
        CreateMap<CustomerSector, UpdatedCustomerSectorResponse>().ReverseMap();
        CreateMap<CustomerSector, DeleteCustomerSectorCommand>().ReverseMap();
        CreateMap<CustomerSector, DeletedCustomerSectorResponse>().ReverseMap();
        CreateMap<CustomerSector, GetByIdCustomerSectorResponse>().ReverseMap();
        CreateMap<CustomerSector, GetListCustomerSectorListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomerSector>, GetListResponse<GetListCustomerSectorListItemDto>>().ReverseMap();
    }
}