using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class fixingSmallDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 6,
                column: "Price",
                value: 210000.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 1,
                column: "Price",
                value: 30000.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 2,
                column: "Price",
                value: 13000.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 3,
                column: "Price",
                value: 25000.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 4,
                column: "Price",
                value: 30000.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 5,
                column: "Price",
                value: 9000.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 6,
                column: "Price",
                value: 2100000.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 1,
                column: "Price",
                value: 30.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 2,
                column: "Price",
                value: 13.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 3,
                column: "Price",
                value: 25.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 4,
                column: "Price",
                value: 30.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 5,
                column: "Price",
                value: 9.0);
        }
    }
}
