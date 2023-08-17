using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CustomerFirmType : Entity<int>
{
    public int CustomerId { get; set; }
    public int FirmTypeId { get; set; }
}
