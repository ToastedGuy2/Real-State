using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class Establishingthecurrencyoftheprojectandupdatingthepriceofitems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 1,
                column: "Price",
                value: 200.0);

            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 2,
                column: "Price",
                value: 250.0);

            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 3,
                column: "Price",
                value: 300.0);

            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 4,
                column: "Price",
                value: 500.0);

            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 5,
                column: "Price",
                value: 660.0);

            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 6,
                column: "Price",
                value: 420.0);

            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 7,
                column: "Price",
                value: 600.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 1,
                column: "Price",
                value: 60.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 2,
                column: "Price",
                value: 26.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 3,
                column: "Price",
                value: 50.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 4,
                column: "Price",
                value: 60.0);

            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 5,
                column: "Price",
                value: 18.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 1,
                column: "Price",
                value: 100000.0);

            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 2,
                column: "Price",
                value: 125000.0);

            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 3,
                column: "Price",
                value: 155000.0);

            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 4,
                column: "Price",
                value: 250000.0);

            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 5,
                column: "Price",
                value: 330000.0);

            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 6,
                column: "Price",
                value: 210000.0);

            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 7,
                column: "Price",
                value: 300000.0);

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
    }
}
