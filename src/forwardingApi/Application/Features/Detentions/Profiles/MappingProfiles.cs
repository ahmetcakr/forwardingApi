using Application.Features.Detentions.Commands.Create;
using Application.Features.Detentions.Commands.Delete;
using Application.Features.Detentions.Commands.Update;
using Application.Features.Detentions.Queries.GetById;
using Application.Features.Detentions.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Detentions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Detention, CreateDetentionCommand>().ReverseMap();
        CreateMap<Detention, CreatedDetentionResponse>().ReverseMap();
        CreateMap<Detention, UpdateDetentionCommand>().ReverseMap();
        CreateMap<Detention, UpdatedDetentionResponse>().ReverseMap();
        CreateMap<Detention, DeleteDetentionCommand>().ReverseMap();
        CreateMap<Detention, DeletedDetentionResponse>().ReverseMap();
        CreateMap<Detention, GetByIdDetentionResponse>().ReverseMap();
        CreateMap<Detention, GetListDetentionListItemDto>().ReverseMap();
        CreateMap<IPaginate<Detention>, GetListResponse<GetListDetentionListItemDto>>().ReverseMap();
    }
}