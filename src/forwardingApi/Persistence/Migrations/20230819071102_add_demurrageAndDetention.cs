using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_demurrageAndDetention : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Demurrages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Day = table.Column<int>(type: "int", nullable: true),
                    Fee = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demurrages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Detentions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Day = table.Column<int>(type: "int", nullable: true),
                    Fee = table.Column<int>(type: "int", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detentions", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 104, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Demurrages.Admin", null },
                    { 105, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Demurrages.Read", null },
                    { 106, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Demurrages.Write", null },
                    { 107, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Demurrages.Add", null },
                    { 108, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Demurrages.Update", null },
                    { 109, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Demurrages.Delete", null },
                    { 110, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Detentions.Admin", null },
                    { 111, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Detentions.Read", null },
                    { 112, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Detentions.Write", null },
                    { 113, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Detentions.Add", null },
                    { 114, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Detentions.Update", null },
                    { 115, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Detentions.Delete", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 71, 94, 148, 230, 147, 154, 229, 44, 65, 54, 86, 174, 190, 63, 167, 219, 231, 205, 83, 248, 68, 23, 195, 28, 24, 142, 13, 235, 50, 122, 245, 79, 99, 40, 42, 191, 46, 75, 45, 1, 175, 49, 109, 52, 67, 219, 26, 156, 102, 105, 189, 235, 75, 112, 30, 169, 31, 50, 183, 144, 99, 109, 238, 197 }, new byte[] { 212, 127, 127, 141, 53, 236, 174, 52, 62, 194, 116, 22, 7, 57, 46, 80, 152, 232, 219, 28, 104, 187, 31, 34, 127, 57, 2, 209, 214, 150, 96, 143, 56, 238, 130, 168, 143, 28, 61, 99, 45, 109, 106, 190, 220, 20, 5, 243, 59, 233, 107, 58, 132, 235, 61, 19, 128, 57, 126, 187, 7, 203, 180, 35, 204, 102, 165, 3, 162, 169, 232, 166, 58, 166, 211, 119, 68, 236, 163, 18, 105, 176, 76, 200, 236, 163, 218, 24, 174, 73, 127, 236, 215, 64, 255, 69, 106, 104, 138, 45, 75, 233, 250, 118, 160, 222, 226, 148, 171, 86, 175, 87, 135, 87, 143, 88, 216, 45, 120, 121, 44, 253, 68, 36, 115, 223, 26, 130 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Demurrages");

            migrationBuilder.DropTable(
                name: "Detentions");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 115);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 64, 61, 143, 37, 32, 254, 246, 127, 234, 40, 110, 15, 65, 90, 47, 227, 175, 67, 192, 62, 216, 90, 237, 181, 56, 37, 53, 63, 255, 94, 223, 214, 26, 53, 5, 236, 149, 41, 241, 212, 74, 64, 123, 125, 11, 170, 17, 123, 119, 11, 123, 102, 66, 30, 95, 37, 13, 148, 214, 97, 112, 110, 106, 170 }, new byte[] { 134, 31, 52, 203, 178, 66, 170, 14, 94, 176, 244, 234, 186, 120, 88, 37, 68, 186, 79, 39, 83, 63, 107, 155, 237, 239, 170, 169, 41, 118, 229, 59, 35, 130, 149, 66, 245, 78, 148, 129, 111, 116, 116, 99, 37, 118, 104, 8, 184, 47, 136, 85, 85, 230, 207, 242, 67, 202, 40, 41, 211, 175, 47, 181, 156, 145, 10, 163, 56, 146, 192, 87, 197, 136, 95, 164, 73, 1, 45, 33, 99, 52, 136, 217, 150, 184, 53, 93, 152, 55, 226, 196, 53, 89, 150, 236, 141, 232, 244, 97, 235, 186, 236, 8, 110, 35, 192, 136, 79, 132, 134, 90, 222, 251, 223, 7, 113, 200, 253, 138, 115, 223, 58, 246, 149, 242, 96, 92 } });
        }
    }
}
