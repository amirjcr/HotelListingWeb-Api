using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelListing.EndPoint.Migrations
{
    public partial class CustomeIdentityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "358d051e-aaac-43e0-ae6d-a81789ba5313");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "4d2d66d2-42fd-40c3-8773-f2081305e191");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "55553472-698c-43e0-8db6-2dc781cdfd11");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "9bc28368-7015-4986-830c-12cfadbaa9f8");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { "55553472-698c-43e0-8db6-2dc781cdfd11", "dubai", 4, "Big Hotel", 4.7999999999999998 },
                    { "9bc28368-7015-4986-830c-12cfadbaa9f8", "Lodon", 2, "Uk Hotel", 4.0 },
                    { "4d2d66d2-42fd-40c3-8773-f2081305e191", "Moskow", 3, "Russia Plus", 5.0 },
                    { "358d051e-aaac-43e0-ae6d-a81789ba5313", "Tehran Satadat Abad", 1, "Espinas plas", 4.3499999999999996 }
                });
        }
    }
}
