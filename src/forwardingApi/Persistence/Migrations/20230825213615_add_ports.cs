using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_ports : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PortName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PortCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ports", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "OperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { 206, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ports.Admin", null },
                    { 207, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ports.Read", null },
                    { 208, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ports.Write", null },
                    { 209, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ports.Add", null },
                    { 210, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ports.Update", null },
                    { 211, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ports.Delete", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 2, 36, 125, 84, 61, 140, 191, 119, 11, 207, 98, 178, 255, 70, 245, 189, 47, 136, 176, 39, 49, 51, 251, 139, 187, 78, 74, 101, 255, 164, 97, 41, 19, 113, 117, 137, 64, 242, 80, 195, 144, 223, 113, 235, 6, 100, 36, 96, 123, 131, 45, 147, 182, 247, 227, 42, 25, 177, 203, 231, 29, 86, 76, 243 }, new byte[] { 42, 212, 255, 242, 231, 81, 184, 142, 110, 133, 119, 193, 135, 48, 63, 167, 49, 242, 111, 56, 62, 48, 251, 196, 13, 206, 24, 164, 59, 38, 182, 147, 45, 38, 1, 71, 43, 204, 128, 119, 82, 60, 52, 2, 118, 66, 44, 239, 69, 51, 121, 189, 120, 118, 136, 23, 145, 67, 123, 38, 211, 20, 8, 143, 165, 131, 231, 108, 43, 245, 190, 228, 230, 41, 67, 10, 216, 187, 160, 29, 155, 78, 216, 110, 117, 79, 211, 250, 104, 102, 124, 126, 167, 94, 166, 140, 162, 183, 104, 186, 172, 76, 204, 212, 46, 35, 142, 161, 161, 39, 248, 152, 23, 138, 152, 214, 241, 26, 123, 168, 199, 5, 255, 42, 203, 106, 8, 204 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ports");

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "OperationClaims",
                keyColumn: "Id",
                keyValue: 211);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 224, 16, 38, 191, 87, 117, 187, 123, 188, 192, 174, 0, 73, 131, 51, 67, 80, 85, 243, 82, 138, 55, 102, 109, 208, 12, 76, 227, 193, 57, 227, 48, 179, 33, 74, 238, 201, 250, 178, 199, 242, 20, 214, 238, 160, 25, 144, 107, 186, 166, 96, 42, 0, 38, 76, 58, 151, 101, 129, 195, 244, 66, 74, 135 }, new byte[] { 16, 195, 176, 87, 67, 62, 106, 56, 215, 151, 103, 209, 54, 29, 42, 253, 17, 101, 217, 96, 76, 110, 236, 84, 151, 136, 139, 152, 250, 27, 108, 72, 127, 53, 72, 240, 238, 137, 75, 71, 234, 36, 246, 27, 90, 58, 62, 223, 123, 70, 225, 225, 242, 225, 94, 200, 12, 231, 185, 61, 135, 32, 146, 85, 118, 166, 236, 112, 20, 131, 29, 38, 126, 246, 238, 155, 214, 207, 64, 192, 44, 91, 146, 219, 1, 156, 9, 138, 4, 95, 86, 30, 72, 59, 34, 139, 106, 53, 142, 252, 28, 120, 32, 196, 246, 52, 194, 234, 113, 186, 71, 191, 232, 188, 8, 169, 77, 117, 124, 204, 79, 4, 99, 96, 122, 87, 104, 129 } });
        }
    }
}
