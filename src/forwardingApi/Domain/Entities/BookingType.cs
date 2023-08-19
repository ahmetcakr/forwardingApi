using Core.Persistence.Repositories;

namespace Domain.Entities;

public class BookingType : Entity<int> 
{
    public string Name { get; set; }
}

