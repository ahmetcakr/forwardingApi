using Application.Features.BookingTypes.Commands.Create;
using Application.Features.BookingTypes.Commands.Delete;
using Application.Features.BookingTypes.Commands.Update;
using Application.Features.BookingTypes.Queries.GetById;
using Application.Features.BookingTypes.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.BookingTypes.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<BookingType, CreateBookingTypeCommand>().ReverseMap();
        CreateMap<BookingType, CreatedBookingTypeResponse>().ReverseMap();
        CreateMap<BookingType, UpdateBookingTypeCommand>().ReverseMap();
        CreateMap<BookingType, UpdatedBookingTypeResponse>().ReverseMap();
        CreateMap<BookingType, DeleteBookingTypeCommand>().ReverseMap();
        CreateMap<BookingType, DeletedBookingTypeResponse>().ReverseMap();
        CreateMap<BookingType, GetByIdBookingTypeResponse>().ReverseMap();
        CreateMap<BookingType, GetListBookingTypeListItemDto>().ReverseMap();
        CreateMap<IPaginate<BookingType>, GetListResponse<GetListBookingTypeListItemDto>>().ReverseMap();
    }
}