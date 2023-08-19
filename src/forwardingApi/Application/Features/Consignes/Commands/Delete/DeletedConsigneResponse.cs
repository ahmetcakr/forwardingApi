using Core.Application.Responses;

namespace Application.Features.Consignes.Commands.Delete;

public class DeletedConsigneResponse : IResponse
{
    public int Id { get; set; }
}