using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Pol : Entity<int>
{
    public string PolName { get; set; }
}

