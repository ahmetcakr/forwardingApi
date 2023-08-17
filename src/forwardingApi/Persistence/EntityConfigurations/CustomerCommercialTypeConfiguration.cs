using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerCommercialTypeConfiguration : IEntityTypeConfiguration<CustomerCommercialType>
{
    public void Configure(EntityTypeBuilder<CustomerCommercialType> builder)
    {
        builder.ToTable("CustomerCommercialTypes").HasKey(cct => cct.Id);

        builder.Property(cct => cct.Id).HasColumnName("Id").IsRequired();
        builder.Property(cct => cct.CustomerId).HasColumnName("CustomerId");
        builder.Property(cct => cct.CommercialTypeId).HasColumnName("CommercialTypeId");
        builder.Property(cct => cct.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cct => cct.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cct => cct.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cct => !cct.DeletedDate.HasValue);
    }
}