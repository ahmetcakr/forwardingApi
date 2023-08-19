using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Feeder : Entity<int>
{
    public string FeederName { get; set; }
}

