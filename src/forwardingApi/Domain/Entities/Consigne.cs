using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Consigne : Entity<int>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}

