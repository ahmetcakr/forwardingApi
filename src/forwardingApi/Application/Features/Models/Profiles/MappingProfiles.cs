using Application.Features.Models.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Booking, GetListBookingListItemDto>().ReverseMap();
        CreateMap<Paginate<Booking>, GetListResponse<GetListBookingListItemDto>>().ReverseMap();
    }
}
