using Application.Features.Groups.Commands.Create;
using Application.Features.Groups.Commands.Delete;
using Application.Features.Groups.Commands.Update;
using Application.Features.Groups.Queries.GetById;
using Application.Features.Groups.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Groups.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Group, CreateGroupCommand>().ReverseMap();
        CreateMap<Group, CreatedGroupResponse>().ReverseMap();
        CreateMap<Group, UpdateGroupCommand>().ReverseMap();
        CreateMap<Group, UpdatedGroupResponse>().ReverseMap();
        CreateMap<Group, DeleteGroupCommand>().ReverseMap();
        CreateMap<Group, DeletedGroupResponse>().ReverseMap();
        CreateMap<Group, GetByIdGroupResponse>().ReverseMap();
        CreateMap<Group, GetListGroupListItemDto>().ReverseMap();
        CreateMap<IPaginate<Group>, GetListResponse<GetListGroupListItemDto>>().ReverseMap();
    }
}