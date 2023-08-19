using Core.Application.Responses;

namespace Application.Features.Feeders.Commands.Create;

public class CreatedFeederResponse : IResponse
{
    public int Id { get; set; }
    public string FeederName { get; set; }
}