using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerFirmTypeConfiguration : IEntityTypeConfiguration<CustomerFirmType>
{
    public void Configure(EntityTypeBuilder<CustomerFirmType> builder)
    {
        builder.ToTable("CustomerFirmTypes").HasKey(cft => cft.Id);

        builder.Property(cft => cft.Id).HasColumnName("Id").IsRequired();
        builder.Property(cft => cft.CustomerId).HasColumnName("CustomerId");
        builder.Property(cft => cft.FirmTypeId).HasColumnName("FirmTypeId");
        builder.Property(cft => cft.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cft => cft.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cft => cft.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cft => !cft.DeletedDate.HasValue);
    }
}