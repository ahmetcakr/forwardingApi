using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CustomerCommercialDetail : Entity<int>
{
    public int CustomerId { get; set; }
    public int CommercialDetailId { get; set; }
}
