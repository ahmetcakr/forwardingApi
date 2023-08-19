using Core.Application.Responses;

namespace Application.Features.Pols.Commands.Update;

public class UpdatedPolResponse : IResponse
{
    public int Id { get; set; }
    public string PolName { get; set; }
}