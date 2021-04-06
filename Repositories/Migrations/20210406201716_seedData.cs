using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositories.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 6,
                column: "Description",
                value: "Four and our ham west miss. Education shameless who middleton agreement how. We in found world chief is at means weeks smile. ");

            migrationBuilder.InsertData(
                table: "House",
                columns: new[] { "HouseId", "Bathrooms", "Bedrooms", "Description", "ImageName", "IsItAvailable", "Name", "Price", "ProvinceId", "Size" },
                values: new object[,]
                {
                    { 8, 1, 2, "Astonished thoroughly unpleasant especially you dispatched bed favourable.", "House8.jpg", true, "House #8", 430.0, 1, 200.0 },
                    { 9, 2, 3, "Astonished thoroughly unpleasant especially you dispatched bed favourable.", "House9.jpg", true, "House #9", 290.0, 2, 300.0 },
                    { 10, 2, 3, "Discovered her his pianoforte insipidity entreaties.", "House10.jpg", true, "House #10", 265.0, 3, 1223.0 },
                    { 11, 2, 4, "We in found world chief is at means weeks smile.", "House11.jpg", true, "House #11", 400.0, 4, 1223.0 },
                    { 12, 1, 4, "Four and our ham west miss. Education shameless who middleton agreement how.", "House12.jpg", true, "House #12", 400.0, 5, 1111.0 },
                    { 13, 1, 4, "Four and our ham west miss. Education shameless who middleton agreement how.", "House13.jpg", true, "House #13", 300.0, 5, 123.0 },
                    { 14, 2, 5, "Four and our ham west miss. Education shameless who middleton agreement how.", "House14.jpg", true, "House #14", 300.0, 6, 325.0 },
                    { 15, 2, 5, "Four and our ham west miss. Education shameless who middleton agreement how.", "House15.jpg", true, "House #15", 1200.0, 7, 100.0 }
                });

            migrationBuilder.InsertData(
                table: "HouseFeature",
                columns: new[] { "HouseId", "FeatureId" },
                values: new object[,]
                {
                    { 8, 1 },
                    { 11, 4 },
                    { 15, 1 },
                    { 12, 2 },
                    { 12, 3 },
                    { 12, 5 },
                    { 12, 6 },
                    { 11, 2 },
                    { 13, 1 },
                    { 13, 3 },
                    { 13, 4 },
                    { 14, 3 },
                    { 14, 4 },
                    { 14, 5 },
                    { 14, 6 },
                    { 13, 2 },
                    { 11, 1 },
                    { 11, 6 },
                    { 9, 5 },
                    { 9, 1 },
                    { 9, 2 },
                    { 8, 5 },
                    { 8, 4 },
                    { 8, 3 },
                    { 9, 6 },
                    { 8, 6 },
                    { 10, 1 },
                    { 10, 2 },
                    { 10, 5 },
                    { 10, 6 },
                    { 8, 2 }
                });

            migrationBuilder.InsertData(
                table: "HouseService",
                columns: new[] { "HouseId", "ServiceId" },
                values: new object[,]
                {
                    { 13, 4 },
                    { 14, 1 },
                    { 13, 5 },
                    { 10, 3 },
                    { 12, 5 },
                    { 10, 4 },
                    { 12, 4 },
                    { 12, 3 },
                    { 12, 2 },
                    { 9, 2 },
                    { 11, 5 },
                    { 8, 1 },
                    { 15, 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 9, 1 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 9, 5 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 9, 6 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 10, 1 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 10, 2 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 10, 5 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 10, 6 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 11, 6 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 12, 6 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 13, 2 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 13, 3 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 14, 3 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 14, 4 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 14, 5 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 14, 6 });

            migrationBuilder.DeleteData(
                table: "HouseFeature",
                keyColumns: new[] { "HouseId", "FeatureId" },
                keyValues: new object[] { 15, 1 });

            migrationBuilder.DeleteData(
                table: "HouseService",
                keyColumns: new[] { "HouseId", "ServiceId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "HouseService",
                keyColumns: new[] { "HouseId", "ServiceId" },
                keyValues: new object[] { 9, 2 });

            migrationBuilder.DeleteData(
                table: "HouseService",
                keyColumns: new[] { "HouseId", "ServiceId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "HouseService",
                keyColumns: new[] { "HouseId", "ServiceId" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.DeleteData(
                table: "HouseService",
                keyColumns: new[] { "HouseId", "ServiceId" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "HouseService",
                keyColumns: new[] { "HouseId", "ServiceId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "HouseService",
                keyColumns: new[] { "HouseId", "ServiceId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "HouseService",
                keyColumns: new[] { "HouseId", "ServiceId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "HouseService",
                keyColumns: new[] { "HouseId", "ServiceId" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "HouseService",
                keyColumns: new[] { "HouseId", "ServiceId" },
                keyValues: new object[] { 13, 4 });

            migrationBuilder.DeleteData(
                table: "HouseService",
                keyColumns: new[] { "HouseId", "ServiceId" },
                keyValues: new object[] { 13, 5 });

            migrationBuilder.DeleteData(
                table: "HouseService",
                keyColumns: new[] { "HouseId", "ServiceId" },
                keyValues: new object[] { 14, 1 });

            migrationBuilder.DeleteData(
                table: "HouseService",
                keyColumns: new[] { "HouseId", "ServiceId" },
                keyValues: new object[] { 15, 2 });

            migrationBuilder.DeleteData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 15);

            migrationBuilder.UpdateData(
                table: "House",
                keyColumn: "HouseId",
                keyValue: 6,
                column: "Description",
                value: " Four and our ham west miss. Education shameless who middleton agreement how. We in found world chief is at means weeks smile. ");
        }
    }
}
