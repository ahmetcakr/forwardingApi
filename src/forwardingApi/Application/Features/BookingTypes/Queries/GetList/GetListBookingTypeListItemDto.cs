using Core.Application.Dtos;

namespace Application.Features.BookingTypes.Queries.GetList;

public class GetListBookingTypeListItemDto : IDto
{
    public int Id { get; set; }
    public string Type { get; set; }
}