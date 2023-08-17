using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CustomerSector : Entity<int>
{
    public int CustomerId { get; set; }
    public int SectorId { get; set; }
}
