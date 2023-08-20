using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class BookingConfiguration : IEntityTypeConfiguration<Booking>
{
    public void Configure(EntityTypeBuilder<Booking> builder)
    {
        builder.ToTable("Bookings").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.CompanyId).HasColumnName("CompanyId");
        builder.Property(b => b.MBLNo).HasColumnName("MBLNo");
        builder.Property(b => b.ProjectNo).HasColumnName("ProjectNo");
        builder.Property(b => b.Etd).HasColumnName("Etd");
        builder.Property(b => b.Eta).HasColumnName("Eta");
        builder.Property(b => b.DeclarationNo).HasColumnName("DeclarationNo");
        builder.Property(b => b.DeclarationDate).HasColumnName("DeclarationDate");
        builder.Property(b => b.OrdinoDate).HasColumnName("OrdinoDate");
        builder.Property(b => b.Region).HasColumnName("Region");
        builder.Property(b => b.Agent).HasColumnName("Agent");
        builder.Property(b => b.Note).HasColumnName("Note");
        builder.Property(b => b.IsOrigin).HasColumnName("IsOrigin");
        builder.Property(b => b.IsCopy).HasColumnName("IsCopy");
        builder.Property(b => b.FileNo).HasColumnName("FileNo");
        builder.Property(b => b.BookingTypeID).HasColumnName("BookingTypeID");
        builder.Property(b => b.PolID).HasColumnName("PolID");
        builder.Property(b => b.PodID).HasColumnName("PodID");
        builder.Property(b => b.RouteID).HasColumnName("RouteID");
        builder.Property(b => b.ShipID).HasColumnName("ShipID");
        builder.Property(b => b.ShipVoyageID).HasColumnName("ShipVoyageID");
        builder.Property(b => b.FeederID).HasColumnName("FeederID");
        builder.Property(b => b.FeederVoyageID).HasColumnName("FeederVoyageID");
        builder.Property(b => b.ShipperID).HasColumnName("ShipperID");
        builder.Property(b => b.ConsigneID).HasColumnName("ConsigneID");
        builder.Property(b => b.NotifyID).HasColumnName("NotifyID");
        builder.Property(b => b.ApplyToID).HasColumnName("ApplyToID");
        builder.Property(b => b.OperationResponsibleID).HasColumnName("OperationResponsibleID");
        builder.Property(b => b.MarketingResponsibleID).HasColumnName("MarketingResponsibleID");
        builder.Property(b => b.DemurrageID).HasColumnName("DemurrageID");
        builder.Property(b => b.DetentionID).HasColumnName("DetentionID");
        builder.Property(b => b.FreeDayID).HasColumnName("FreeDayID");
        builder.Property(b => b.TotalFeeID).HasColumnName("TotalFeeID");
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(b => b.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Id, name: "UK_Booking_ID").IsUnique();

        builder.HasOne(b => b.Ship).WithMany().HasForeignKey(b => b.ShipID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.Consigne).WithMany().HasForeignKey(b => b.ConsigneID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.Notify).WithMany().HasForeignKey(b => b.NotifyID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.ApplyTo).WithMany().HasForeignKey(b => b.ApplyToID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.OperationResponsible).WithMany().HasForeignKey(b => b.OperationResponsibleID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.MarketingResponsible).WithMany().HasForeignKey(b => b.MarketingResponsibleID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.Demurrage).WithMany().HasForeignKey(b => b.DemurrageID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.Detention).WithMany().HasForeignKey(b => b.DetentionID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.FreeDay).WithMany().HasForeignKey(b => b.FreeDayID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.TotalFee).WithMany().HasForeignKey(b => b.TotalFeeID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.BookingType).WithMany().HasForeignKey(b => b.BookingTypeID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.Pol).WithMany().HasForeignKey(b => b.PolID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.Pod).WithMany().HasForeignKey(b => b.PodID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.Route).WithMany().HasForeignKey(b => b.RouteID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.ShipVoyage).WithMany().HasForeignKey(b => b.ShipVoyageID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.Feeder).WithMany().HasForeignKey(b => b.FeederID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.FeederVoyage).WithMany().HasForeignKey(b => b.FeederVoyageID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.Shipper).WithMany().HasForeignKey(b => b.ShipperID).OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(b => b.Company).WithMany().HasForeignKey(b => b.CompanyId).OnDelete(DeleteBehavior.NoAction);



        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}