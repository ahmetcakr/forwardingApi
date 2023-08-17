using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerSectorConfiguration : IEntityTypeConfiguration<CustomerSector>
{
    public void Configure(EntityTypeBuilder<CustomerSector> builder)
    {
        builder.ToTable("CustomerSectors").HasKey(cs => cs.Id);

        builder.Property(cs => cs.Id).HasColumnName("Id").IsRequired();
        builder.Property(cs => cs.CustomerId).HasColumnName("CustomerId");
        builder.Property(cs => cs.SectorId).HasColumnName("SectorId");
        builder.Property(cs => cs.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cs => cs.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cs => cs.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cs => !cs.DeletedDate.HasValue);
    }
}