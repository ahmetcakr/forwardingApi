using Core.Persistence.Repositories;

namespace Domain.Entities;

public class EBill : Entity<int>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? Mail { get; set; }
}
