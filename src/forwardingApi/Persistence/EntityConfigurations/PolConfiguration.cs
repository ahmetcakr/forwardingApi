using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class PolConfiguration : IEntityTypeConfiguration<Pol>
{
    public void Configure(EntityTypeBuilder<Pol> builder)
    {
        builder.ToTable("Pols").HasKey(p => p.Id);

        builder.Property(p => p.Id).HasColumnName("Id").IsRequired();
        builder.Property(p => p.PolName).HasColumnName("PolName");
        builder.Property(p => p.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(p => p.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(p => !p.DeletedDate.HasValue);
    }
}