using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Pod : Entity<int> 
{
    public string PodName { get; set; }
}

