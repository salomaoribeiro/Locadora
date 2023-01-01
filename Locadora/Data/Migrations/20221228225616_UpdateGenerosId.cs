using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Data.Migrations
{
    public partial class UpdateGenerosId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Generos_GeneroId",
                table: "Filmes");

            migrationBuilder.RenameColumn(
                name: "GeneroId",
                table: "Filmes",
                newName: "GenerosId");

            migrationBuilder.RenameIndex(
                name: "IX_Filmes_GeneroId",
                table: "Filmes",
                newName: "IX_Filmes_GenerosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Generos_GenerosId",
                table: "Filmes",
                column: "GenerosId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filmes_Generos_GenerosId",
                table: "Filmes");

            migrationBuilder.RenameColumn(
                name: "GenerosId",
                table: "Filmes",
                newName: "GeneroId");

            migrationBuilder.RenameIndex(
                name: "IX_Filmes_GenerosId",
                table: "Filmes",
                newName: "IX_Filmes_GeneroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filmes_Generos_GeneroId",
                table: "Filmes",
                column: "GeneroId",
                principalTable: "Generos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
