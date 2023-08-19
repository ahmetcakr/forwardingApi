using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Domain.Entities;

namespace Persistence.Contexts;

public class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; set; }
    public DbSet<EmailAuthenticator> EmailAuthenticators { get; set; }
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<OtpAuthenticator> OtpAuthenticators { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CommercialDetail> CommercialDetails { get; set; }
    public DbSet<CommercialType> CommercialTypes { get; set; }
    public DbSet<CustomerCommercialDetail> CustomerCommercialDetails { get; set; }
    public DbSet<CustomerCommercialType> CustomerCommercialTypes { get; set; }
    public DbSet<CustomerEBill> CustomerEBills { get; set; }
    public DbSet<CustomerFirmType> CustomerFirmTypes { get; set; }
    public DbSet<CustomerGroup> CustomerGroups { get; set; }
    public DbSet<CustomerSector> CustomerSectors { get; set; }
    public DbSet<EBill> EBills { get; set; }
    public DbSet<FirmType> FirmTypes { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<Demurrage> Demurrages { get; set; }
    public DbSet<Detention> Detentions { get; set; }
    public DbSet<Feeder> Feeders { get; set; }

    public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration)
        : base(dbContextOptions)
    {
        Configuration = configuration;
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
}
