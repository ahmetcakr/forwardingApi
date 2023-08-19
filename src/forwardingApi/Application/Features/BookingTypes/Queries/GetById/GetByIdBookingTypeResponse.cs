using Core.Application.Responses;

namespace Application.Features.BookingTypes.Queries.GetById;

public class GetByIdBookingTypeResponse : IResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
}