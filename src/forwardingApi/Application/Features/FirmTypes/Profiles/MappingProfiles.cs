using Application.Features.FirmTypes.Commands.Create;
using Application.Features.FirmTypes.Commands.Delete;
using Application.Features.FirmTypes.Commands.Update;
using Application.Features.FirmTypes.Queries.GetById;
using Application.Features.FirmTypes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.FirmTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<FirmType, CreateFirmTypeCommand>().ReverseMap();
        CreateMap<FirmType, CreatedFirmTypeResponse>().ReverseMap();
        CreateMap<FirmType, UpdateFirmTypeCommand>().ReverseMap();
        CreateMap<FirmType, UpdatedFirmTypeResponse>().ReverseMap();
        CreateMap<FirmType, DeleteFirmTypeCommand>().ReverseMap();
        CreateMap<FirmType, DeletedFirmTypeResponse>().ReverseMap();
        CreateMap<FirmType, GetByIdFirmTypeResponse>().ReverseMap();
        CreateMap<FirmType, GetListFirmTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<FirmType>, GetListResponse<GetListFirmTypeListItemDto>>().ReverseMap();
    }
}