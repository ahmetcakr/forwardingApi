using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CommercialTypeConfiguration : IEntityTypeConfiguration<CommercialType>
{
    public void Configure(EntityTypeBuilder<CommercialType> builder)
    {
        builder.ToTable("CommercialTypes").HasKey(ct => ct.Id);

        builder.Property(ct => ct.Id).HasColumnName("Id").IsRequired();
        builder.Property(ct => ct.Name).HasColumnName("Name");
        builder.Property(ct => ct.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ct => ct.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ct => ct.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ct => !ct.DeletedDate.HasValue);
    }
}