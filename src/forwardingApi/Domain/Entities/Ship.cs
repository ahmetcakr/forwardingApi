using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Ship : Entity<int>
{
    public string ShipName { get; set; }
}
