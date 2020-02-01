using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmian.Migrations
{
    public partial class H : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nacionalidad",
                table: "Directores");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Paises",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "NacionalidadPaisId",
                table: "Directores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Paises_Nombre",
                table: "Paises",
                column: "Nombre");

            migrationBuilder.CreateIndex(
                name: "IX_Directores_NacionalidadPaisId",
                table: "Directores",
                column: "NacionalidadPaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Directores_Paises_NacionalidadPaisId",
                table: "Directores",
                column: "NacionalidadPaisId",
                principalTable: "Paises",
                principalColumn: "PaisId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directores_Paises_NacionalidadPaisId",
                table: "Directores");

            migrationBuilder.DropIndex(
                name: "IX_Paises_Nombre",
                table: "Paises");

            migrationBuilder.DropIndex(
                name: "IX_Directores_NacionalidadPaisId",
                table: "Directores");

            migrationBuilder.DropColumn(
                name: "NacionalidadPaisId",
                table: "Directores");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Paises",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Nacionalidad",
                table: "Directores",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
