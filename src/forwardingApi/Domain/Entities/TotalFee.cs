using Core.Persistence.Repositories;

namespace Domain.Entities;

public class TotalFee : Entity<int>
{
    public int? Fee { get; set; }
    public int? Vat { get; set; }
    public int? Total { get; set; }
}

