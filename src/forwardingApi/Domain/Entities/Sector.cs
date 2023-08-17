using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Sector : Entity<int>
{
    public string Name { get; set; }
}