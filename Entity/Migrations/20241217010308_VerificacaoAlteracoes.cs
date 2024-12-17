using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    public partial class VerificacaoAlteracoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Economias_EconomiaId",
                table: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Empresas_EconomiaId",
                table: "Empresas");

            migrationBuilder.DropColumn(
                name: "EconomiaId",
                table: "Empresas");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaId",
                table: "Economias",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpresaId",
                table: "Economias");

            migrationBuilder.AddColumn<int>(
                name: "EconomiaId",
                table: "Empresas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Empresas_EconomiaId",
                table: "Empresas",
                column: "EconomiaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Economias_EconomiaId",
                table: "Empresas",
                column: "EconomiaId",
                principalTable: "Economias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
