using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerEBillConfiguration : IEntityTypeConfiguration<CustomerEBill>
{
    public void Configure(EntityTypeBuilder<CustomerEBill> builder)
    {
        builder.ToTable("CustomerEBills").HasKey(ceb => ceb.Id);

        builder.Property(ceb => ceb.Id).HasColumnName("Id").IsRequired();
        builder.Property(ceb => ceb.CustomerId).HasColumnName("CustomerId");
        builder.Property(ceb => ceb.EBillId).HasColumnName("EBillId");
        builder.Property(ceb => ceb.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ceb => ceb.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ceb => ceb.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ceb => !ceb.DeletedDate.HasValue);
    }
}