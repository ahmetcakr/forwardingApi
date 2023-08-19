using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Voyage : Entity<int>
{
    public string VoyageName { get; set; }
}

