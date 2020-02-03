using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmian.Migrations
{
    public partial class O : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Directores",
                keyColumn: "DirectorID",
                keyValue: (short)1,
                column: "FechaNacimiento",
                value: new DateTime(1918, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Directores",
                keyColumn: "DirectorID",
                keyValue: (short)2,
                column: "FechaNacimiento",
                value: new DateTime(1956, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Directores",
                keyColumn: "DirectorID",
                keyValue: (short)3,
                column: "FechaNacimiento",
                value: new DateTime(1932, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Directores",
                keyColumn: "DirectorID",
                keyValue: (short)1,
                column: "FechaNacimiento",
                value: new DateTime(1918, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Directores",
                keyColumn: "DirectorID",
                keyValue: (short)2,
                column: "FechaNacimiento",
                value: new DateTime(1956, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Directores",
                keyColumn: "DirectorID",
                keyValue: (short)3,
                column: "FechaNacimiento",
                value: new DateTime(1932, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
