using Application.Features.OperationClaims.Constants;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class OperationClaimConfiguration : IEntityTypeConfiguration<OperationClaim>
{
    public void Configure(EntityTypeBuilder<OperationClaim> builder)
    {
        builder.ToTable("OperationClaims").HasKey(oc => oc.Id);

        builder.Property(oc => oc.Id).HasColumnName("Id").IsRequired();
        builder.Property(oc => oc.Name).HasColumnName("Name").IsRequired();
        builder.Property(oc => oc.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(oc => oc.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(oc => oc.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(oc => !oc.DeletedDate.HasValue);

        builder.HasMany(oc => oc.UserOperationClaims);

        builder.HasData(getSeeds());
    }

    private HashSet<OperationClaim> getSeeds()
    {
        int id = 0;
        HashSet<OperationClaim> seeds =
            new()
            {
                new OperationClaim { Id = ++id, Name = GeneralOperationClaims.Admin }
            };

        
        #region Customers
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Customers.Delete" });
        
        #endregion
        
        
        #region CommercialDetails
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialDetails.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialDetails.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialDetails.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialDetails.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialDetails.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialDetails.Delete" });
        
        #endregion
        
        
        #region CommercialTypes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialTypes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialTypes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialTypes.Delete" });
        
        #endregion
        
        
        #region CommercialDetails
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialDetails.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialDetails.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialDetails.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialDetails.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialDetails.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialDetails.Delete" });
        
        #endregion
        
        
        #region CommercialTypes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialTypes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialTypes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CommercialTypes.Delete" });
        
        #endregion
        
        
        #region CustomerCommercialDetails
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCommercialDetails.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCommercialDetails.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCommercialDetails.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCommercialDetails.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCommercialDetails.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCommercialDetails.Delete" });
        
        #endregion
        
        
        #region CustomerCommercialTypes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCommercialTypes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCommercialTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCommercialTypes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCommercialTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCommercialTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerCommercialTypes.Delete" });
        
        #endregion
        
        
        #region CustomerEBills
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerEBills.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerEBills.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerEBills.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerEBills.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerEBills.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerEBills.Delete" });
        
        #endregion
        
        
        #region CustomerEBills
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerEBills.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerEBills.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerEBills.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerEBills.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerEBills.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerEBills.Delete" });
        
        #endregion
        
        
        #region CustomerFirmTypes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerFirmTypes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerFirmTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerFirmTypes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerFirmTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerFirmTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerFirmTypes.Delete" });
        
        #endregion
        
        
        #region CustomerFirmTypes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerFirmTypes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerFirmTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerFirmTypes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerFirmTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerFirmTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerFirmTypes.Delete" });
        
        #endregion
        
        
        #region CustomerGroups
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerGroups.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerGroups.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerGroups.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerGroups.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerGroups.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerGroups.Delete" });
        
        #endregion
        
        
        #region CustomerSectors
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerSectors.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerSectors.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerSectors.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerSectors.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerSectors.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "CustomerSectors.Delete" });
        
        #endregion
        
        
        #region EBills
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "EBills.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "EBills.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EBills.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "EBills.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EBills.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "EBills.Delete" });
        
        #endregion
        
        
        #region FirmTypes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "FirmTypes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "FirmTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "FirmTypes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "FirmTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "FirmTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "FirmTypes.Delete" });
        
        #endregion
        
        
        #region Groups
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Groups.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Groups.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Groups.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Groups.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Groups.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Groups.Delete" });
        
        #endregion
        
        
        #region Sectors
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sectors.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sectors.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sectors.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sectors.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sectors.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Sectors.Delete" });
        
        #endregion
        
        
        #region Demurrages
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Demurrages.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Demurrages.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Demurrages.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Demurrages.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Demurrages.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Demurrages.Delete" });
        
        #endregion
        
        
        #region Detentions
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Detentions.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Detentions.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Detentions.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Detentions.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Detentions.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Detentions.Delete" });
        
        #endregion
        
        
        #region Feeders
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Feeders.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Feeders.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Feeders.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Feeders.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Feeders.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Feeders.Delete" });
        
        #endregion
        
        
        #region BookingTypes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "BookingTypes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "BookingTypes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "BookingTypes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "BookingTypes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "BookingTypes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "BookingTypes.Delete" });
        
        #endregion
        
        
        #region Consignes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Consignes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Consignes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Consignes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Consignes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Consignes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Consignes.Delete" });
        
        #endregion
        
        
        #region FreeDays
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "FreeDays.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "FreeDays.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "FreeDays.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "FreeDays.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "FreeDays.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "FreeDays.Delete" });
        
        #endregion
        
        
        #region Pods
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Pods.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Pods.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Pods.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Pods.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Pods.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Pods.Delete" });
        
        #endregion
        
        
        #region Pols
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Pols.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Pols.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Pols.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Pols.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Pols.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Pols.Delete" });
        
        #endregion
        
        
        #region Routes
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Routes.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Routes.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Routes.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Routes.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Routes.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Routes.Delete" });
        
        #endregion
        
        
        #region Ships
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Ships.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Ships.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Ships.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "Ships.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Ships.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "Ships.Delete" });
        
        #endregion
        
        
        #region TotalFees
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "TotalFees.Admin" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "TotalFees.Read" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "TotalFees.Write" });
        
        seeds.Add(new OperationClaim { Id = ++id, Name = "TotalFees.Add" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "TotalFees.Update" });
        seeds.Add(new OperationClaim { Id = ++id, Name = "TotalFees.Delete" });
        
        #endregion
        
        return seeds;
    }
}
