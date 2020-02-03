using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmian.Migrations
{
    public partial class M : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Directores",
                keyColumn: "DirectorID",
                keyValue: (short)1,
                column: "FechaNacimiento",
                value: new DateTime(1918, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Directores",
                columns: new[] { "DirectorID", "FechaNacimiento", "Nombre", "PaisId" },
                values: new object[,]
                {
                    { (short)2, new DateTime(1956, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lars von Trier", 22 },
                    { (short)3, new DateTime(1932, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Andréi Tarkovski", 50 }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "DirectorId", "Duracion", "Titulo" },
                values: new object[,]
                {
                    { (short)1, (short)1, (short)96, "El séptimo sello" },
                    { (short)2, (short)1, (short)85, "Persona" },
                    { (short)3, (short)1, (short)106, "Gritos y susurros" }
                });

            migrationBuilder.InsertData(
                table: "Peliculas",
                columns: new[] { "PeliculaId", "DirectorId", "Duracion", "Titulo" },
                values: new object[,]
                {
                    { (short)4, (short)2, (short)136, "Melancolía" },
                    { (short)5, (short)2, (short)179, "Dogville" },
                    { (short)6, (short)2, (short)117, "Los idiotas" },
                    { (short)7, (short)3, (short)163, "Stalker" },
                    { (short)8, (short)3, (short)169, "Solaris" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)1);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)3);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)4);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)5);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)6);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)7);

            migrationBuilder.DeleteData(
                table: "Peliculas",
                keyColumn: "PeliculaId",
                keyValue: (short)8);

            migrationBuilder.DeleteData(
                table: "Directores",
                keyColumn: "DirectorID",
                keyValue: (short)2);

            migrationBuilder.DeleteData(
                table: "Directores",
                keyColumn: "DirectorID",
                keyValue: (short)3);

            migrationBuilder.UpdateData(
                table: "Directores",
                keyColumn: "DirectorID",
                keyValue: (short)1,
                column: "FechaNacimiento",
                value: new DateTime(1918, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
