using Core.Persistence.Repositories;

namespace Domain.Entities;

public class FirmType : Entity<int>
{
    public string Name { get; set; }
}
