using Application.Features.CustomerGroups.Commands.Create;
using Application.Features.CustomerGroups.Commands.Delete;
using Application.Features.CustomerGroups.Commands.Update;
using Application.Features.CustomerGroups.Queries.GetById;
using Application.Features.CustomerGroups.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CustomerGroups.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerGroup, CreateCustomerGroupCommand>().ReverseMap();
        CreateMap<CustomerGroup, CreatedCustomerGroupResponse>().ReverseMap();
        CreateMap<CustomerGroup, UpdateCustomerGroupCommand>().ReverseMap();
        CreateMap<CustomerGroup, UpdatedCustomerGroupResponse>().ReverseMap();
        CreateMap<CustomerGroup, DeleteCustomerGroupCommand>().ReverseMap();
        CreateMap<CustomerGroup, DeletedCustomerGroupResponse>().ReverseMap();
        CreateMap<CustomerGroup, GetByIdCustomerGroupResponse>().ReverseMap();
        CreateMap<CustomerGroup, GetListCustomerGroupListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomerGroup>, GetListResponse<GetListCustomerGroupListItemDto>>().ReverseMap();
    }
}