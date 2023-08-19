using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Demurrage : Entity<int>
{
    public DateTime? StartDate { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }
}

