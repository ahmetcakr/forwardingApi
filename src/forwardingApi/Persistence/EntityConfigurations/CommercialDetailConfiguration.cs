using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CommercialDetailConfiguration : IEntityTypeConfiguration<CommercialDetail>
{
    public void Configure(EntityTypeBuilder<CommercialDetail> builder)
    {
        builder.ToTable("CommercialDetails").HasKey(cd => cd.Id);

        builder.Property(cd => cd.Id).HasColumnName("Id").IsRequired();
        builder.Property(cd => cd.TaxOffice).HasColumnName("TaxOffice");
        builder.Property(cd => cd.TaxOfficeNo).HasColumnName("TaxOfficeNo");
        builder.Property(cd => cd.Bank).HasColumnName("Bank");
        builder.Property(cd => cd.BankAccountNo).HasColumnName("BankAccountNo");
        builder.Property(cd => cd.BankDetail).HasColumnName("BankDetail");
        builder.Property(cd => cd.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cd => cd.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cd => cd.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cd => !cd.DeletedDate.HasValue);
    }
}