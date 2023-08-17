using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Group : Entity<int>
{
    public string Name { get; set; }
}
