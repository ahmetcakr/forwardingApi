using Application.Features.TotalFees.Commands.Create;
using Application.Features.TotalFees.Commands.Delete;
using Application.Features.TotalFees.Commands.Update;
using Application.Features.TotalFees.Queries.GetById;
using Application.Features.TotalFees.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.TotalFees.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<TotalFee, CreateTotalFeeCommand>().ReverseMap();
        CreateMap<TotalFee, CreatedTotalFeeResponse>().ReverseMap();
        CreateMap<TotalFee, UpdateTotalFeeCommand>().ReverseMap();
        CreateMap<TotalFee, UpdatedTotalFeeResponse>().ReverseMap();
        CreateMap<TotalFee, DeleteTotalFeeCommand>().ReverseMap();
        CreateMap<TotalFee, DeletedTotalFeeResponse>().ReverseMap();
        CreateMap<TotalFee, GetByIdTotalFeeResponse>().ReverseMap();
        CreateMap<TotalFee, GetListTotalFeeListItemDto>().ReverseMap();
        CreateMap<IPaginate<TotalFee>, GetListResponse<GetListTotalFeeListItemDto>>().ReverseMap();
    }
}