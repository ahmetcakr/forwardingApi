using Core.Persistence.Repositories;

namespace Domain.Entities;

public class FreeDay : Entity<int>
{
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Day { get; set; }
    public int? Fee { get; set; }
    public int? Total { get; set; }
    public int? TotalFee { get; set; }
}

