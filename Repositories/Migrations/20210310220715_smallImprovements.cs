using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class smallImprovements : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 3,
                column: "Name",
                value: "Garden");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Service",
                keyColumn: "ServiceId",
                keyValue: 3,
                column: "Name",
                value: "Garden..");
        }
    }
}
