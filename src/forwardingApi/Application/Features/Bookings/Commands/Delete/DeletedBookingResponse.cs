using Core.Application.Responses;

namespace Application.Features.Bookings.Commands.Delete;

public class DeletedBookingResponse : IResponse
{
    public int Id { get; set; }
}