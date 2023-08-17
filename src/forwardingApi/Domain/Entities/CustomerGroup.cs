using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CustomerGroup : Entity<int>
{
    public int CustomerId { get; set; }
    public int GroupId { get; set; }
}
