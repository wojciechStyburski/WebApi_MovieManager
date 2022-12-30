#nullable disable

namespace MovieManager.Infrastructure.DataAccessLayer.Migations
{
    public partial class Genresadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("08625d7c-1fd3-4bfa-ae7f-9f4f279dbdfd"), "Dramat" },
                    { new Guid("0b8a19b6-b2b3-4eb4-8f6e-710fd729ca9e"), "Dokumentalny" },
                    { new Guid("0e77696c-db1a-4e63-9373-801fd73af288"), "Musical" },
                    { new Guid("336e9f8a-78a1-4e72-97a2-b8cde37d41f7"), "Akcja" },
                    { new Guid("3444c4d1-fa54-4e71-a330-79b5c86b48a2"), "Thriller" },
                    { new Guid("918894d8-8813-481d-9fe8-11f9146f8954"), "Horror" },
                    { new Guid("f745f7f3-58f9-4e24-ba83-d3e1a09cee34"), "Komedia" },
                    { new Guid("f83ca6b7-6df7-4526-8d06-8ae5d246e3a0"), "Science fiction" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("08625d7c-1fd3-4bfa-ae7f-9f4f279dbdfd"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0b8a19b6-b2b3-4eb4-8f6e-710fd729ca9e"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("0e77696c-db1a-4e63-9373-801fd73af288"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("336e9f8a-78a1-4e72-97a2-b8cde37d41f7"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("3444c4d1-fa54-4e71-a330-79b5c86b48a2"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("918894d8-8813-481d-9fe8-11f9146f8954"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f745f7f3-58f9-4e24-ba83-d3e1a09cee34"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("f83ca6b7-6df7-4526-8d06-8ae5d246e3a0"));
        }
    }
}
