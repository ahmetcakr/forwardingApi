using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FirmTypeConfiguration : IEntityTypeConfiguration<FirmType>
{
    public void Configure(EntityTypeBuilder<FirmType> builder)
    {
        builder.ToTable("FirmTypes").HasKey(ft => ft.Id);

        builder.Property(ft => ft.Id).HasColumnName("Id").IsRequired();
        builder.Property(ft => ft.Name).HasColumnName("Name");
        builder.Property(ft => ft.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(ft => ft.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(ft => ft.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(ft => !ft.DeletedDate.HasValue);
    }
}