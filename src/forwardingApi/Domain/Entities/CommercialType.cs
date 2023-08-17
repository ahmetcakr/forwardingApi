using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CommercialType : Entity<int>
{
    public string Name { get; set; }
}
