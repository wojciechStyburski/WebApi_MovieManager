using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieManager.Infrastructure.DataAccessLayer.Migations
{
    public partial class Seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "DirectorName_FirstName", "DirectorName_LastName" },
                values: new object[] { new Guid("51a340e7-c0b9-465c-89d9-2c931b712514"), "Andrzej", "Wajda" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorId", "Name", "ReleaseYear" },
                values: new object[] { new Guid("3f25d6fd-db78-49a9-9d79-e210abf7fa5f"), new Guid("51a340e7-c0b9-465c-89d9-2c931b712514"), "Pan Tadeusz", 1999 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "DirectorId", "Name", "ReleaseYear" },
                values: new object[] { new Guid("aba6cf27-8f2a-4c85-b75d-ea9a0065ac40"), new Guid("51a340e7-c0b9-465c-89d9-2c931b712514"), "Popiół i diament", 1958 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("3f25d6fd-db78-49a9-9d79-e210abf7fa5f"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("aba6cf27-8f2a-4c85-b75d-ea9a0065ac40"));

            migrationBuilder.DeleteData(
                table: "Directors",
                keyColumn: "Id",
                keyValue: new Guid("51a340e7-c0b9-465c-89d9-2c931b712514"));
        }
    }
}
