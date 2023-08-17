using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class EBillConfiguration : IEntityTypeConfiguration<EBill>
{
    public void Configure(EntityTypeBuilder<EBill> builder)
    {
        builder.ToTable("EBills").HasKey(eb => eb.Id);

        builder.Property(eb => eb.Id).HasColumnName("Id").IsRequired();
        builder.Property(eb => eb.Name).HasColumnName("Name");
        builder.Property(eb => eb.Description).HasColumnName("Description");
        builder.Property(eb => eb.Phone).HasColumnName("Phone");
        builder.Property(eb => eb.Address).HasColumnName("Address");
        builder.Property(eb => eb.Mail).HasColumnName("Mail");
        builder.Property(eb => eb.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(eb => eb.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(eb => eb.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(eb => !eb.DeletedDate.HasValue);
    }
}