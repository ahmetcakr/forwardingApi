using Core.Application.Responses;

namespace Application.Features.Feeders.Commands.Update;

public class UpdatedFeederResponse : IResponse
{
    public int Id { get; set; }
    public string FeederName { get; set; }
}