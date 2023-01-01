using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Locadora.Data.Migrations
{
  public partial class PopularNomeAssinaturas : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      //string[] colunas = { "Nome"};
      object[] row = {"Pague por uso", "Mensal", "Trimestral", "Anual"};
      object[] keys = { 1, 2, 3, 4 };

      migrationBuilder.UpdateData("Assinaturas", "Id", keys, "Nome", row);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {

    }
  }
}
