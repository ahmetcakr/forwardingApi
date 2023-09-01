using Core.Application.Responses;

namespace Application.Features.Ports.Queries.GetById;

public class GetByIdPortResponse : IResponse
{
    public int Id { get; set; }
    public string PortName { get; set; }
    public string PortCode { get; set; }
    public string CountryCode { get; set; }
    public string CountryName { get; set; }
    public string Region { get; set; }
}