using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class FreeDayConfiguration : IEntityTypeConfiguration<FreeDay>
{
    public void Configure(EntityTypeBuilder<FreeDay> builder)
    {
        builder.ToTable("FreeDays").HasKey(fd => fd.Id);

        builder.Property(fd => fd.Id).HasColumnName("Id").IsRequired();
        builder.Property(fd => fd.StartDate).HasColumnName("StartDate");
        builder.Property(fd => fd.EndDate).HasColumnName("EndDate");
        builder.Property(fd => fd.Day).HasColumnName("Day");
        builder.Property(fd => fd.Fee).HasColumnName("Fee");
        builder.Property(fd => fd.Total).HasColumnName("Total");
        builder.Property(fd => fd.TotalFee).HasColumnName("TotalFee");
        builder.Property(fd => fd.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(fd => fd.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(fd => fd.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(fd => !fd.DeletedDate.HasValue);
    }
}