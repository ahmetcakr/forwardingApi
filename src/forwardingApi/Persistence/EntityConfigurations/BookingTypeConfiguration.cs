using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BookingTypeConfiguration : IEntityTypeConfiguration<BookingType>
{
    public void Configure(EntityTypeBuilder<BookingType> builder)
    {
        builder.ToTable("BookingTypes").HasKey(bt => bt.Id);

        builder.Property(bt => bt.Id).HasColumnName("Id").IsRequired();
        builder.Property(bt => bt.Type).HasColumnName("Type");
        builder.Property(bt => bt.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(bt => bt.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(bt => bt.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(bt => !bt.DeletedDate.HasValue);
    }
}