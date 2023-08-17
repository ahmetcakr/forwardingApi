using Application.Features.CustomerEBills.Commands.Create;
using Application.Features.CustomerEBills.Commands.Delete;
using Application.Features.CustomerEBills.Commands.Update;
using Application.Features.CustomerEBills.Queries.GetById;
using Application.Features.CustomerEBills.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CustomerEBills.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CustomerEBill, CreateCustomerEBillCommand>().ReverseMap();
        CreateMap<CustomerEBill, CreatedCustomerEBillResponse>().ReverseMap();
        CreateMap<CustomerEBill, UpdateCustomerEBillCommand>().ReverseMap();
        CreateMap<CustomerEBill, UpdatedCustomerEBillResponse>().ReverseMap();
        CreateMap<CustomerEBill, DeleteCustomerEBillCommand>().ReverseMap();
        CreateMap<CustomerEBill, DeletedCustomerEBillResponse>().ReverseMap();
        CreateMap<CustomerEBill, GetByIdCustomerEBillResponse>().ReverseMap();
        CreateMap<CustomerEBill, GetListCustomerEBillListItemDto>().ReverseMap();
        CreateMap<IPaginate<CustomerEBill>, GetListResponse<GetListCustomerEBillListItemDto>>().ReverseMap();
    }
}