using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelListing.EndPoint.Migrations
{
    public partial class SeedingData1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "colunries",
                columns: new[] { "Id", "Countrycode", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, (short)98, "IRAN", "IR" },
                    { 2, (short)3, "UNITED KINGDOM", "UK" },
                    { 3, (short)7, "RUSSIA", "RU" },
                    { 4, (short)11, "UNITED EMART ARIBA", "UEA" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Address", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { "647f924e-48c5-4b34-8fb0-e168a47f002e", "Tehran Satadat Abad", 1, "Espinas plas", 4.3499999999999996 },
                    { "ff4c66e3-c0a8-4a78-830e-d16da6380608", "Lodon", 2, "Uk Hotel", 4.0 },
                    { "fb830bcf-68f0-4142-a3f1-b1a562d1f3dd", "Moskow", 3, "Russia Plus", 5.0 },
                    { "bd2a578f-ac27-4c12-86c7-d72a51f83bca", "dubai", 4, "Big Hotel", 4.7999999999999998 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "647f924e-48c5-4b34-8fb0-e168a47f002e");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "bd2a578f-ac27-4c12-86c7-d72a51f83bca");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "fb830bcf-68f0-4142-a3f1-b1a562d1f3dd");

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: "ff4c66e3-c0a8-4a78-830e-d16da6380608");

            migrationBuilder.DeleteData(
                table: "colunries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "colunries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "colunries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "colunries",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
