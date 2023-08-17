using Core.Persistence.Repositories;

namespace Domain.Entities;

public class CustomerEBill : Entity<int>
{
    public int CustomerId { get; set; }
    public int EBillId { get; set; }
}
