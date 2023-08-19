using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Detention : Entity<int>
{
    public int? Day { get; set; }
    public int? Fee { get; set; }
}

