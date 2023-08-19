using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class TotalFeeConfiguration : IEntityTypeConfiguration<TotalFee>
{
    public void Configure(EntityTypeBuilder<TotalFee> builder)
    {
        builder.ToTable("TotalFees").HasKey(tf => tf.Id);

        builder.Property(tf => tf.Id).HasColumnName("Id").IsRequired();
        builder.Property(tf => tf.Fee).HasColumnName("Fee");
        builder.Property(tf => tf.Vat).HasColumnName("Vat");
        builder.Property(tf => tf.Total).HasColumnName("Total");
        builder.Property(tf => tf.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(tf => tf.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(tf => tf.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(tf => !tf.DeletedDate.HasValue);
    }
}