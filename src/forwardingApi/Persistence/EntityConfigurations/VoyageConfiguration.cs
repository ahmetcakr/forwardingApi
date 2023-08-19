using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class VoyageConfiguration : IEntityTypeConfiguration<Voyage>
{
    public void Configure(EntityTypeBuilder<Voyage> builder)
    {
        builder.ToTable("Voyages").HasKey(v => v.Id);

        builder.Property(v => v.Id).HasColumnName("Id").IsRequired();
        builder.Property(v => v.VoyageName).HasColumnName("VoyageName");
        builder.Property(v => v.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(v => v.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(v => v.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(v => !v.DeletedDate.HasValue);
    }
}