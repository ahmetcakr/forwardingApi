using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_companyMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Company_CompanyId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Company",
                table: "Company");

            migrationBuilder.RenameTable(
                name: "Company",
                newName: "Companies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 188, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BookingTypes.Admin", null },
                    { 189, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BookingTypes.Read", null },
                    { 190, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BookingTypes.Write", null },
                    { 191, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BookingTypes.Add", null },
                    { 192, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BookingTypes.Update", null },
                    { 193, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "BookingTypes.Delete", null },
                    { 194, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Companies.Admin", null },
                    { 195, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Companies.Read", null },
                    { 196, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Companies.Write", null },
                    { 197, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Companies.Add", null },
                    { 198, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Companies.Update", null },
                    { 199, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Companies.Delete", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 149, 47, 65, 10, 153, 139, 240, 177, 235, 215, 139, 66, 120, 255, 238, 183, 88, 128, 72, 139, 126, 127, 161, 32, 146, 9, 178, 23, 228, 143, 163, 195, 210, 11, 78, 52, 237, 124, 189, 230, 91, 205, 81, 18, 38, 252, 235, 26, 117, 245, 71, 210, 190, 7, 66, 119, 28, 5, 134, 179, 145, 12, 116, 183 }, new byte[] { 241, 103, 67, 29, 200, 22, 245, 61, 67, 117, 121, 149, 113, 120, 10, 146, 122, 227, 46, 233, 35, 191, 32, 93, 135, 7, 136, 97, 161, 197, 54, 220, 115, 199, 69, 101, 109, 68, 217, 40, 78, 85, 189, 56, 98, 149, 238, 121, 238, 68, 133, 59, 215, 50, 214, 96, 193, 187, 249, 217, 208, 221, 78, 137, 27, 160, 83, 29, 118, 196, 100, 193, 126, 139, 147, 229, 159, 195, 126, 207, 126, 0, 12, 155, 72, 190, 58, 226, 241, 54, 199, 186, 102, 94, 103, 116, 200, 167, 224, 193, 121, 168, 107, 200, 57, 161, 114, 223, 176, 208, 59, 192, 42, 70, 61, 126, 209, 123, 161, 40, 117, 245, 101, 121, 188, 227, 37, 138 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Companies_CompanyId",
                table: "Bookings",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Companies_CompanyId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 199);

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Company");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Company",
                table: "Company",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 86, 57, 207, 32, 25, 2, 176, 198, 75, 250, 237, 88, 210, 241, 241, 34, 204, 0, 201, 193, 153, 155, 40, 208, 96, 113, 33, 188, 142, 89, 207, 8, 215, 211, 91, 134, 233, 86, 18, 157, 54, 227, 231, 103, 136, 223, 136, 57, 226, 167, 144, 202, 204, 198, 14, 122, 145, 170, 250, 100, 6, 11, 248, 178 }, new byte[] { 213, 248, 108, 12, 153, 79, 87, 10, 170, 91, 42, 176, 121, 70, 49, 135, 110, 112, 149, 147, 141, 232, 59, 190, 162, 115, 219, 202, 16, 55, 90, 103, 170, 38, 140, 139, 129, 194, 130, 101, 13, 33, 22, 116, 142, 112, 104, 49, 125, 209, 227, 202, 116, 195, 238, 231, 244, 98, 118, 149, 52, 246, 195, 7, 15, 154, 187, 88, 8, 10, 80, 247, 160, 117, 160, 191, 122, 86, 147, 246, 105, 183, 130, 145, 110, 203, 225, 28, 17, 228, 95, 215, 176, 13, 194, 208, 50, 108, 106, 204, 91, 88, 69, 231, 225, 78, 150, 152, 198, 219, 70, 3, 246, 131, 167, 133, 186, 111, 41, 49, 29, 83, 238, 58, 118, 114, 73, 216 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Company_CompanyId",
                table: "Bookings",
                column: "CompanyId",
                principalTable: "Company",
                principalColumn: "Id");
        }
    }
}
