using Core.Application.Responses;

namespace Application.Features.Companies.Commands.Create;

public class CreatedCompanyResponse : IResponse
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
}