using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CustomerCommercialType : Entity<int>
{
    public int CustomerId { get; set; }
    public int CommercialTypeId { get; set; }
}
