using Microsoft.EntityFrameworkCore.Migrations;

namespace Filmian.Migrations
{
    public partial class J : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directores_Paises_NacionalidadPaisId",
                table: "Directores");

            migrationBuilder.DropIndex(
                name: "IX_Directores_NacionalidadPaisId",
                table: "Directores");

            migrationBuilder.DropColumn(
                name: "NacionalidadPaisId",
                table: "Directores");

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                table: "Directores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Directores_PaisId",
                table: "Directores",
                column: "PaisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Directores_Paises_PaisId",
                table: "Directores",
                column: "PaisId",
                principalTable: "Paises",
                principalColumn: "PaisId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directores_Paises_PaisId",
                table: "Directores");

            migrationBuilder.DropIndex(
                name: "IX_Directores_PaisId",
                table: "Directores");

            migrationBuilder.DropColumn(
                name: "PaisId",
                table: "Directores");

            migrationBuilder.AddColumn<int>(
                name: "NacionalidadPaisId",
                table: "Directores",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
