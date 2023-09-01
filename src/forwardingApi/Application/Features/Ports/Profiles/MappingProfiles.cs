using Application.Features.Ports.Commands.Create;
using Application.Features.Ports.Commands.Delete;
using Application.Features.Ports.Commands.Update;
using Application.Features.Ports.Queries.GetById;
using Application.Features.Ports.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Ports.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Port, CreatePortCommand>().ReverseMap();
        CreateMap<Port, CreatedPortResponse>().ReverseMap();
        CreateMap<Port, UpdatePortCommand>().ReverseMap();
        CreateMap<Port, UpdatedPortResponse>().ReverseMap();
        CreateMap<Port, DeletePortCommand>().ReverseMap();
        CreateMap<Port, DeletedPortResponse>().ReverseMap();
        CreateMap<Port, GetByIdPortResponse>().ReverseMap();
        CreateMap<Port, GetListPortListItemDto>().ReverseMap();
        CreateMap<IPaginate<Port>, GetListResponse<GetListPortListItemDto>>().ReverseMap();
    }
}