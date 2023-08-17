using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerCommercialDetailConfiguration : IEntityTypeConfiguration<CustomerCommercialDetail>
{
    public void Configure(EntityTypeBuilder<CustomerCommercialDetail> builder)
    {
        builder.ToTable("CustomerCommercialDetails").HasKey(ccd => ccd.Id);

        builder.Property(ccd => ccd.Id).HasColumnName("Id").IsRequired();
        builder.Property(ccd => ccd.CustomerId).HasColumnName("CustomerId");
        builder.Property(ccd => ccd.CommercialDetailId).HasColumnName("CommercialDetailId");
        builder.Property(ccd => ccd.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ccd => ccd.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ccd => ccd.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ccd => !ccd.DeletedDate.HasValue);
    }
}