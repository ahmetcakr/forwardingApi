using Core.Application.Responses;

namespace Application.Features.BookingTypes.Commands.Create;

public class CreatedBookingTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Type { get; set; }
}