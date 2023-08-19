using Application.Features.Bookings.Commands.Create;
using Application.Features.Bookings.Commands.Delete;
using Application.Features.Bookings.Commands.Update;
using Application.Features.Bookings.Queries.GetById;
using Application.Features.Bookings.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Bookings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Booking, CreateBookingCommand>().ReverseMap();
        CreateMap<Booking, CreatedBookingResponse>().ReverseMap();
        CreateMap<Booking, UpdateBookingCommand>().ReverseMap();
        CreateMap<Booking, UpdatedBookingResponse>().ReverseMap();
        CreateMap<Booking, DeleteBookingCommand>().ReverseMap();
        CreateMap<Booking, DeletedBookingResponse>().ReverseMap();
        CreateMap<Booking, GetByIdBookingResponse>().ReverseMap();
        CreateMap<Booking, GetListBookingListItemDto>().ReverseMap();
        CreateMap<IPaginate<Booking>, GetListResponse<GetListBookingListItemDto>>().ReverseMap();
    }
}