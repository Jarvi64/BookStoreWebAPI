using System;
using Microsoft.EntityFrameworkCore.Migrations;#nullable disable#pragma warning disable CA1814 // Prefer jagged arrays over multidimensionalnamespace BookStoreWebAPI.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "AuthorId", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("1f4e4f7c-6377-473f-bb25-0b31a1c95af3"), "India", "William Lee" },
                    { new Guid("92fda86a-c051-4c4d-819e-cde2abbc0971"), "Canada", "Michael Johnson" },
                    { new Guid("9a1ab2f9-d8c0-4a0c-a185-40e9137ef5a2"), "South Korea", "Sophia Kim" },
                    { new Guid("a8210012-4e0b-4f8c-b4e0-0857e8de30b0"), "United States", "John Doe" },
                    { new Guid("d69536a2-71c8-43ac-aed3-0209a4f5a8db"), "Australia", "Emily Brown" },
                    { new Guid("e9831d11-87ae-4540-9b9c-3c04b3c71cc7"), "United Kingdom", "Jane Smith" }
                });            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { new Guid("25290ad1-9ff5-4ed7-817e-3d90ff2f600e"), "Romance" },
                    { new Guid("2ecdf04f-70cd-4df7-aaed-5e84221cbace"), "Fiction" },
                    { new Guid("9f0bfd52-5aff-4b2b-9fb4-751ec7c53be0"), "Mystery" },
                    { new Guid("e786fcd3-0a66-4e12-85c4-86f27886dde4"), "Fantasy" },
                    { new Guid("f76e5b2b-8ef8-45e4-a910-93bc89e68dac"), "Science Fiction" }
                });
        }        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("1f4e4f7c-6377-473f-bb25-0b31a1c95af3"));            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("92fda86a-c051-4c4d-819e-cde2abbc0971"));            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("9a1ab2f9-d8c0-4a0c-a185-40e9137ef5a2"));            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("a8210012-4e0b-4f8c-b4e0-0857e8de30b0"));            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("d69536a2-71c8-43ac-aed3-0209a4f5a8db"));            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "AuthorId",
                keyValue: new Guid("e9831d11-87ae-4540-9b9c-3c04b3c71cc7"));            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: new Guid("25290ad1-9ff5-4ed7-817e-3d90ff2f600e"));            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: new Guid("2ecdf04f-70cd-4df7-aaed-5e84221cbace"));            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: new Guid("9f0bfd52-5aff-4b2b-9fb4-751ec7c53be0"));            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: new Guid("e786fcd3-0a66-4e12-85c4-86f27886dde4"));            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: new Guid("f76e5b2b-8ef8-45e4-a910-93bc89e68dac"));
        }
    }
}
