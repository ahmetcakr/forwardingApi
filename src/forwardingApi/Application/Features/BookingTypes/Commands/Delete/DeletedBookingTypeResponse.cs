using Core.Application.Responses;

namespace Application.Features.BookingTypes.Commands.Delete;

public class DeletedBookingTypeResponse : IResponse
{
    public int Id { get; set; }
}