using Application.Features.EBills.Commands.Create;
using Application.Features.EBills.Commands.Delete;
using Application.Features.EBills.Commands.Update;
using Application.Features.EBills.Queries.GetById;
using Application.Features.EBills.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.EBills.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<EBill, CreateEBillCommand>().ReverseMap();
        CreateMap<EBill, CreatedEBillResponse>().ReverseMap();
        CreateMap<EBill, UpdateEBillCommand>().ReverseMap();
        CreateMap<EBill, UpdatedEBillResponse>().ReverseMap();
        CreateMap<EBill, DeleteEBillCommand>().ReverseMap();
        CreateMap<EBill, DeletedEBillResponse>().ReverseMap();
        CreateMap<EBill, GetByIdEBillResponse>().ReverseMap();
        CreateMap<EBill, GetListEBillListItemDto>().ReverseMap();
        CreateMap<IPaginate<EBill>, GetListResponse<GetListEBillListItemDto>>().ReverseMap();
    }
}