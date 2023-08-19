using Application.Features.Pods.Commands.Create;
using Application.Features.Pods.Commands.Delete;
using Application.Features.Pods.Commands.Update;
using Application.Features.Pods.Queries.GetById;
using Application.Features.Pods.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Pods.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Pod, CreatePodCommand>().ReverseMap();
        CreateMap<Pod, CreatedPodResponse>().ReverseMap();
        CreateMap<Pod, UpdatePodCommand>().ReverseMap();
        CreateMap<Pod, UpdatedPodResponse>().ReverseMap();
        CreateMap<Pod, DeletePodCommand>().ReverseMap();
        CreateMap<Pod, DeletedPodResponse>().ReverseMap();
        CreateMap<Pod, GetByIdPodResponse>().ReverseMap();
        CreateMap<Pod, GetListPodListItemDto>().ReverseMap();
        CreateMap<IPaginate<Pod>, GetListResponse<GetListPodListItemDto>>().ReverseMap();
    }
}