using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmian.Migrations
{
    public partial class L : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Directores",
                nullable: false,
                defaultValue: new DateTime(2020, 2, 3, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Directores",
                columns: new[] { "DirectorID", "FechaNacimiento", "Nombre", "PaisId" },
                values: new object[] { (short)1, new DateTime(1918, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ingmar Bergman", 67 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Directores",
                keyColumn: "DirectorID",
                keyValue: (short)1);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaNacimiento",
                table: "Directores",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Local),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 2, 3, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
