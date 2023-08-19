using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class bookingConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Type",
                table: "BookingTypes",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyId = table.Column<int>(type: "int", nullable: false),
                    MBLNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Etd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Eta = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeclarationNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeclarationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OrdinoDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Agent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsOrigin = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCopy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BookingTypeID = table.Column<int>(type: "int", nullable: false),
                    PolID = table.Column<int>(type: "int", nullable: false),
                    PodID = table.Column<int>(type: "int", nullable: false),
                    RouteID = table.Column<int>(type: "int", nullable: true),
                    ShipID = table.Column<int>(type: "int", nullable: false),
                    ShipVoyageID = table.Column<int>(type: "int", nullable: true),
                    FeederID = table.Column<int>(type: "int", nullable: false),
                    FeederVoyageID = table.Column<int>(type: "int", nullable: false),
                    ShipperID = table.Column<int>(type: "int", nullable: false),
                    ConsigneID = table.Column<int>(type: "int", nullable: true),
                    NotifyID = table.Column<int>(type: "int", nullable: true),
                    ApplyToID = table.Column<int>(type: "int", nullable: false),
                    OperationResponsibleID = table.Column<int>(type: "int", nullable: true),
                    MarketingResponsibleID = table.Column<int>(type: "int", nullable: true),
                    DemurrageID = table.Column<int>(type: "int", nullable: true),
                    DetentionID = table.Column<int>(type: "int", nullable: true),
                    FreeDayID = table.Column<int>(type: "int", nullable: true),
                    TotalFeeID = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_BookingTypes_BookingTypeID",
                        column: x => x.BookingTypeID,
                        principalTable: "BookingTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Company_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Company",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_ApplyToID",
                        column: x => x.ApplyToID,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_ConsigneID",
                        column: x => x.ConsigneID,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_NotifyID",
                        column: x => x.NotifyID,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Customers_ShipperID",
                        column: x => x.ShipperID,
                        principalTable: "Customers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Demurrages_DemurrageID",
                        column: x => x.DemurrageID,
                        principalTable: "Demurrages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Detentions_DetentionID",
                        column: x => x.DetentionID,
                        principalTable: "Detentions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Feeders_FeederID",
                        column: x => x.FeederID,
                        principalTable: "Feeders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_FreeDays_FreeDayID",
                        column: x => x.FreeDayID,
                        principalTable: "FreeDays",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Pods_PodID",
                        column: x => x.PodID,
                        principalTable: "Pods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Pols_PolID",
                        column: x => x.PolID,
                        principalTable: "Pols",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Routes_RouteID",
                        column: x => x.RouteID,
                        principalTable: "Routes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Ships_ShipID",
                        column: x => x.ShipID,
                        principalTable: "Ships",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_TotalFees_TotalFeeID",
                        column: x => x.TotalFeeID,
                        principalTable: "TotalFees",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Users_MarketingResponsibleID",
                        column: x => x.MarketingResponsibleID,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Users_OperationResponsibleID",
                        column: x => x.OperationResponsibleID,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Voyages_FeederVoyageID",
                        column: x => x.FeederVoyageID,
                        principalTable: "Voyages",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bookings_Voyages_ShipVoyageID",
                        column: x => x.ShipVoyageID,
                        principalTable: "Voyages",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 176, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bookings.Admin", null },
                    { 177, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bookings.Read", null },
                    { 178, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bookings.Write", null },
                    { 179, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bookings.Add", null },
                    { 180, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bookings.Update", null },
                    { 181, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bookings.Delete", null },
                    { 182, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bookings.Admin", null },
                    { 183, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bookings.Read", null },
                    { 184, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bookings.Write", null },
                    { 185, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bookings.Add", null },
                    { 186, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bookings.Update", null },
                    { 187, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Bookings.Delete", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 86, 57, 207, 32, 25, 2, 176, 198, 75, 250, 237, 88, 210, 241, 241, 34, 204, 0, 201, 193, 153, 155, 40, 208, 96, 113, 33, 188, 142, 89, 207, 8, 215, 211, 91, 134, 233, 86, 18, 157, 54, 227, 231, 103, 136, 223, 136, 57, 226, 167, 144, 202, 204, 198, 14, 122, 145, 170, 250, 100, 6, 11, 248, 178 }, new byte[] { 213, 248, 108, 12, 153, 79, 87, 10, 170, 91, 42, 176, 121, 70, 49, 135, 110, 112, 149, 147, 141, 232, 59, 190, 162, 115, 219, 202, 16, 55, 90, 103, 170, 38, 140, 139, 129, 194, 130, 101, 13, 33, 22, 116, 142, 112, 104, 49, 125, 209, 227, 202, 116, 195, 238, 231, 244, 98, 118, 149, 52, 246, 195, 7, 15, 154, 187, 88, 8, 10, 80, 247, 160, 117, 160, 191, 122, 86, 147, 246, 105, 183, 130, 145, 110, 203, 225, 28, 17, 228, 95, 215, 176, 13, 194, 208, 50, 108, 106, 204, 91, 88, 69, 231, 225, 78, 150, 152, 198, 219, 70, 3, 246, 131, 167, 133, 186, 111, 41, 49, 29, 83, 238, 58, 118, 114, 73, 216 } });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ApplyToID",
                table: "Bookings",
                column: "ApplyToID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BookingTypeID",
                table: "Bookings",
                column: "BookingTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CompanyId",
                table: "Bookings",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ConsigneID",
                table: "Bookings",
                column: "ConsigneID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DemurrageID",
                table: "Bookings",
                column: "DemurrageID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_DetentionID",
                table: "Bookings",
                column: "DetentionID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FeederID",
                table: "Bookings",
                column: "FeederID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FeederVoyageID",
                table: "Bookings",
                column: "FeederVoyageID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_FreeDayID",
                table: "Bookings",
                column: "FreeDayID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_MarketingResponsibleID",
                table: "Bookings",
                column: "MarketingResponsibleID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_NotifyID",
                table: "Bookings",
                column: "NotifyID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_OperationResponsibleID",
                table: "Bookings",
                column: "OperationResponsibleID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PodID",
                table: "Bookings",
                column: "PodID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_PolID",
                table: "Bookings",
                column: "PolID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RouteID",
                table: "Bookings",
                column: "RouteID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ShipID",
                table: "Bookings",
                column: "ShipID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ShipperID",
                table: "Bookings",
                column: "ShipperID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ShipVoyageID",
                table: "Bookings",
                column: "ShipVoyageID");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_TotalFeeID",
                table: "Bookings",
                column: "TotalFeeID");

            migrationBuilder.CreateIndex(
                name: "UK_Booking_ID",
                table: "Bookings",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 187);

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "BookingTypes",
                newName: "Type");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 161, 205, 21, 149, 70, 157, 92, 58, 74, 196, 180, 231, 199, 32, 172, 109, 193, 127, 73, 20, 42, 200, 42, 63, 207, 105, 254, 201, 61, 113, 138, 162, 60, 192, 90, 4, 239, 88, 247, 48, 254, 12, 190, 233, 255, 207, 234, 128, 159, 224, 96, 234, 125, 186, 245, 29, 91, 51, 149, 1, 78, 17, 113, 118 }, new byte[] { 15, 75, 103, 93, 244, 68, 215, 124, 188, 220, 112, 19, 35, 177, 175, 246, 32, 101, 16, 138, 189, 186, 248, 134, 209, 132, 72, 119, 236, 55, 70, 192, 13, 206, 70, 178, 52, 89, 30, 229, 152, 196, 126, 16, 216, 126, 107, 142, 142, 8, 40, 223, 192, 231, 79, 69, 226, 167, 220, 155, 42, 177, 113, 160, 28, 61, 144, 227, 166, 169, 234, 138, 188, 215, 224, 159, 169, 245, 109, 221, 132, 168, 144, 63, 255, 35, 122, 0, 57, 189, 58, 147, 49, 162, 165, 116, 177, 170, 19, 133, 237, 224, 234, 242, 182, 118, 238, 184, 60, 213, 58, 67, 222, 160, 51, 78, 169, 31, 185, 128, 5, 41, 4, 229, 210, 156, 72, 178 } });
        }
    }
}
