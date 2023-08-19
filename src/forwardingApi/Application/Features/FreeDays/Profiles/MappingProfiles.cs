using Application.Features.FreeDays.Commands.Create;
using Application.Features.FreeDays.Commands.Delete;
using Application.Features.FreeDays.Commands.Update;
using Application.Features.FreeDays.Queries.GetById;
using Application.Features.FreeDays.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.FreeDays.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<FreeDay, CreateFreeDayCommand>().ReverseMap();
        CreateMap<FreeDay, CreatedFreeDayResponse>().ReverseMap();
        CreateMap<FreeDay, UpdateFreeDayCommand>().ReverseMap();
        CreateMap<FreeDay, UpdatedFreeDayResponse>().ReverseMap();
        CreateMap<FreeDay, DeleteFreeDayCommand>().ReverseMap();
        CreateMap<FreeDay, DeletedFreeDayResponse>().ReverseMap();
        CreateMap<FreeDay, GetByIdFreeDayResponse>().ReverseMap();
        CreateMap<FreeDay, GetListFreeDayListItemDto>().ReverseMap();
        CreateMap<IPaginate<FreeDay>, GetListResponse<GetListFreeDayListItemDto>>().ReverseMap();
    }
}