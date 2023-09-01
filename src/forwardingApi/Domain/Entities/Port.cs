using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Port : Entity<int>
{
    public string PortName { get; set; }
    public string PortCode { get; set; }
    public string CountryCode { get; set; }
    public string CountryName { get; set; }
    public string Region { get; set; }
}
