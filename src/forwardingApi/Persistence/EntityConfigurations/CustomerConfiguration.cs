using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {
        builder.ToTable("Customers").HasKey(c => c.Id);

        builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
        builder.Property(c => c.CustomerCode).HasColumnName("CustomerCode");
        builder.Property(c => c.CustomerName).HasColumnName("CustomerName");
        builder.Property(c => c.Address).HasColumnName("Address");
        builder.Property(c => c.City).HasColumnName("City");
        builder.Property(c => c.Region).HasColumnName("Region");
        builder.Property(c => c.PostalCode).HasColumnName("PostalCode");
        builder.Property(c => c.Country).HasColumnName("Country");
        builder.Property(c => c.Phone).HasColumnName("Phone");
        builder.Property(c => c.Mail).HasColumnName("Mail");
        builder.Property(c => c.CommercialDetailId).HasColumnName("CommercialDetailId");
        builder.Property(c => c.CommercialTypeId).HasColumnName("CommercialTypeId");
        builder.Property(c => c.EBillId).HasColumnName("EBillId");
        builder.Property(c => c.FirmTypeId).HasColumnName("FirmTypeId");
        builder.Property(c => c.GroupId).HasColumnName("GroupId");
        builder.Property(c => c.SectorId).HasColumnName("SectorId");
        builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Id, name: "UK_Customer_ID").IsUnique();

        builder.HasOne(b => b.CommercialDetail).WithMany().HasForeignKey(b => b.CommercialDetailId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.CommercialType).WithMany().HasForeignKey(b => b.CommercialTypeId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.EBill).WithMany().HasForeignKey(b => b.EBillId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.FirmType).WithMany().HasForeignKey(b => b.FirmTypeId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.Group).WithMany().HasForeignKey(b => b.GroupId).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.Sector).WithMany().HasForeignKey(b => b.SectorId).OnDelete(DeleteBehavior.NoAction);

        builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
    }
}