using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Company : Entity<int>
{
    public string CompanyName { get; set; }
}

