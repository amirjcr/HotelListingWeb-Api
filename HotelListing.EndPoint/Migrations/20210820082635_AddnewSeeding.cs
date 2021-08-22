using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelListing.EndPoint.Migrations
{
    public partial class AddnewSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "44ae6a04-58b6-4370-b016-8bca607419af");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "7957a6e7-fbc5-411a-9e72-fed4f3e08206");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "8df9bb56-cac9-4eae-bd88-e7d488e6baaf");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "d5fc9573-99d2-4574-9acb-847453e39bbb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dcd2b543-7247-483d-aa3f-6fe2edf2fcc5", "7b6207da-c8ac-485b-83b1-9b7acc45f408", "user", "USER" },
                    { "afa69c94-a8ef-4f3d-985a-ded2d55268d3", "12226695-4ed0-4329-a345-9175fb9e51ea", "admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { "db7a8857-e9a0-4916-a39a-b5f01f49d0c5", "dubai", 4, "Big Hotel", 4.7999999999999998 },
                    { "4592621b-98f0-4d84-972d-a008c909c57a", "Lodon", 2, "Uk Hotel", 4.0 },
                    { "aeb8d715-43bd-4ee7-a16f-611486333fad", "Moskow", 3, "Russia Plus", 5.0 },
                    { "d97eddda-36a7-4b33-9d47-10c0013d1a27", "Tehran Satadat Abad", 1, "Espinas plas", 4.3499999999999996 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "afa69c94-a8ef-4f3d-985a-ded2d55268d3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcd2b543-7247-483d-aa3f-6fe2edf2fcc5");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "4592621b-98f0-4d84-972d-a008c909c57a");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "aeb8d715-43bd-4ee7-a16f-611486333fad");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "d97eddda-36a7-4b33-9d47-10c0013d1a27");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "db7a8857-e9a0-4916-a39a-b5f01f49d0c5");

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { "7957a6e7-fbc5-411a-9e72-fed4f3e08206", "dubai", 4, "Big Hotel", 4.7999999999999998 },
                    { "8df9bb56-cac9-4eae-bd88-e7d488e6baaf", "Lodon", 2, "Uk Hotel", 4.0 },
                    { "44ae6a04-58b6-4370-b016-8bca607419af", "Moskow", 3, "Russia Plus", 5.0 },
                    { "d5fc9573-99d2-4574-9acb-847453e39bbb", "Tehran Satadat Abad", 1, "Espinas plas", 4.3499999999999996 }
                });
        }
    }
}
