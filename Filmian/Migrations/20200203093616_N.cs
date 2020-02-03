using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmian.Migrations
{
    public partial class N : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "Año",
                table: "Peliculas",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<decimal>(
                name: "Valoracion",
                table: "Peliculas",
                nullable: false,
                defaultValue: 0m);

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

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)1,
                columns: new[] { "Año", "Valoracion" },
                values: new object[] { (short)1957, 8.2m });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)2,
                columns: new[] { "Año", "Valoracion" },
                values: new object[] { (short)1966, 8.2m });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)3,
                columns: new[] { "Año", "Valoracion" },
                values: new object[] { (short)1972, 7.8m });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)4,
                columns: new[] { "Año", "Valoracion" },
                values: new object[] { (short)2011, 6.8m });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)5,
                columns: new[] { "Año", "Valoracion" },
                values: new object[] { (short)2003, 7.5m });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)6,
                columns: new[] { "Año", "Valoracion" },
                values: new object[] { (short)1998, 6.6m });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)7,
                columns: new[] { "Año", "Valoracion" },
                values: new object[] { (short)1972, 7.9m });

            migrationBuilder.UpdateData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)8,
                columns: new[] { "Año", "Valoracion" },
                values: new object[] { (short)1972, 7.5m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Año",
                table: "Peliculas");

            migrationBuilder.DropColumn(
                name: "Valoracion",
                table: "Peliculas");

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
