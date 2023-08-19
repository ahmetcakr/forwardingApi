using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class RouteConfiguration : IEntityTypeConfiguration<Route>
{
    public void Configure(EntityTypeBuilder<Route> builder)
    {
        builder.ToTable("Routes").HasKey(r => r.Id);

        builder.Property(r => r.Id).HasColumnName("Id").IsRequired();
        builder.Property(r => r.RouteName).HasColumnName("RouteName");
        builder.Property(r => r.RouteCode).HasColumnName("RouteCode");
        builder.Property(r => r.RouteDescription).HasColumnName("RouteDescription");
        builder.Property(r => r.RouteType).HasColumnName("RouteType");
        builder.Property(r => r.RouteStatus).HasColumnName("RouteStatus");
        builder.Property(r => r.RouteNote).HasColumnName("RouteNote");
        builder.Property(r => r.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(r => r.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(r => r.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(r => !r.DeletedDate.HasValue);
    }
}