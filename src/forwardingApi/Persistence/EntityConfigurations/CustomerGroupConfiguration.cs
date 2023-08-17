using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class CustomerGroupConfiguration : IEntityTypeConfiguration<CustomerGroup>
{
    public void Configure(EntityTypeBuilder<CustomerGroup> builder)
    {
        builder.ToTable("CustomerGroups").HasKey(cg => cg.Id);

        builder.Property(cg => cg.Id).HasColumnName("Id").IsRequired();
        builder.Property(cg => cg.CustomerId).HasColumnName("CustomerId");
        builder.Property(cg => cg.GroupId).HasColumnName("GroupId");
        builder.Property(cg => cg.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(cg => cg.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(cg => cg.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(cg => !cg.DeletedDate.HasValue);
    }
}