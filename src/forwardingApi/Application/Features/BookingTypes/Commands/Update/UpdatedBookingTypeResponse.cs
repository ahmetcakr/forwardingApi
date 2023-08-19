using Core.Application.Responses;

namespace Application.Features.BookingTypes.Commands.Update;

public class UpdatedBookingTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}