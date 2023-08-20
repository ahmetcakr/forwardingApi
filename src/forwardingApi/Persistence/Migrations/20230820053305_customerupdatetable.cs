using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class customerupdatetable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommercialDetailId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommercialTypeId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EBillId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FirmTypeId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SectorId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 200, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customers.Admin", null },
                    { 201, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customers.Read", null },
                    { 202, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customers.Write", null },
                    { 203, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customers.Add", null },
                    { 204, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customers.Update", null },
                    { 205, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Customers.Delete", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 224, 16, 38, 191, 87, 117, 187, 123, 188, 192, 174, 0, 73, 131, 51, 67, 80, 85, 243, 82, 138, 55, 102, 109, 208, 12, 76, 227, 193, 57, 227, 48, 179, 33, 74, 238, 201, 250, 178, 199, 242, 20, 214, 238, 160, 25, 144, 107, 186, 166, 96, 42, 0, 38, 76, 58, 151, 101, 129, 195, 244, 66, 74, 135 }, new byte[] { 16, 195, 176, 87, 67, 62, 106, 56, 215, 151, 103, 209, 54, 29, 42, 253, 17, 101, 217, 96, 76, 110, 236, 84, 151, 136, 139, 152, 250, 27, 108, 72, 127, 53, 72, 240, 238, 137, 75, 71, 234, 36, 246, 27, 90, 58, 62, 223, 123, 70, 225, 225, 242, 225, 94, 200, 12, 231, 185, 61, 135, 32, 146, 85, 118, 166, 236, 112, 20, 131, 29, 38, 126, 246, 238, 155, 214, 207, 64, 192, 44, 91, 146, 219, 1, 156, 9, 138, 4, 95, 86, 30, 72, 59, 34, 139, 106, 53, 142, 252, 28, 120, 32, 196, 246, 52, 194, 234, 113, 186, 71, 191, 232, 188, 8, 169, 77, 117, 124, 204, 79, 4, 99, 96, 122, 87, 104, 129 } });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CommercialDetailId",
                table: "Customers",
                column: "CommercialDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CommercialTypeId",
                table: "Customers",
                column: "CommercialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_EBillId",
                table: "Customers",
                column: "EBillId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FirmTypeId",
                table: "Customers",
                column: "FirmTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_GroupId",
                table: "Customers",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_SectorId",
                table: "Customers",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "UK_Customer_ID",
                table: "Customers",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CommercialDetails_CommercialDetailId",
                table: "Customers",
                column: "CommercialDetailId",
                principalTable: "CommercialDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_CommercialTypes_CommercialTypeId",
                table: "Customers",
                column: "CommercialTypeId",
                principalTable: "CommercialTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_EBills_EBillId",
                table: "Customers",
                column: "EBillId",
                principalTable: "EBills",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_FirmTypes_FirmTypeId",
                table: "Customers",
                column: "FirmTypeId",
                principalTable: "FirmTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Groups_GroupId",
                table: "Customers",
                column: "GroupId",
                principalTable: "Groups",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Sectors_SectorId",
                table: "Customers",
                column: "SectorId",
                principalTable: "Sectors",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CommercialDetails_CommercialDetailId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_CommercialTypes_CommercialTypeId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_EBills_EBillId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_FirmTypes_FirmTypeId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Groups_GroupId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Sectors_SectorId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CommercialDetailId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CommercialTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_EBillId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_FirmTypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_GroupId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_SectorId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "UK_Customer_ID",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 205);

            migrationBuilder.DropColumn(
                name: "CommercialDetailId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CommercialTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "EBillId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FirmTypeId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "SectorId",
                table: "Customers");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 149, 47, 65, 10, 153, 139, 240, 177, 235, 215, 139, 66, 120, 255, 238, 183, 88, 128, 72, 139, 126, 127, 161, 32, 146, 9, 178, 23, 228, 143, 163, 195, 210, 11, 78, 52, 237, 124, 189, 230, 91, 205, 81, 18, 38, 252, 235, 26, 117, 245, 71, 210, 190, 7, 66, 119, 28, 5, 134, 179, 145, 12, 116, 183 }, new byte[] { 241, 103, 67, 29, 200, 22, 245, 61, 67, 117, 121, 149, 113, 120, 10, 146, 122, 227, 46, 233, 35, 191, 32, 93, 135, 7, 136, 97, 161, 197, 54, 220, 115, 199, 69, 101, 109, 68, 217, 40, 78, 85, 189, 56, 98, 149, 238, 121, 238, 68, 133, 59, 215, 50, 214, 96, 193, 187, 249, 217, 208, 221, 78, 137, 27, 160, 83, 29, 118, 196, 100, 193, 126, 139, 147, 229, 159, 195, 126, 207, 126, 0, 12, 155, 72, 190, 58, 226, 241, 54, 199, 186, 102, 94, 103, 116, 200, 167, 224, 193, 121, 168, 107, 200, 57, 161, 114, 223, 176, 208, 59, 192, 42, 70, 61, 126, 209, 123, 161, 40, 117, 245, 101, 121, 188, 227, 37, 138 } });
        }
    }
}
