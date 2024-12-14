using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    public partial class AtualizacaoTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo",
                table: "Usuario");

            migrationBuilder.AddColumn<int>(
                name: "TipoUsuarioId",
                table: "Usuario",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Step",
                table: "Cargos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TiposUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Tipo = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuario", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_TipoUsuarioId",
                table: "Usuario",
                column: "TipoUsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_TiposUsuario_TipoUsuarioId",
                table: "Usuario",
                column: "TipoUsuarioId",
                principalTable: "TiposUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_TiposUsuario_TipoUsuarioId",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "TiposUsuario");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_TipoUsuarioId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "TipoUsuarioId",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Step",
                table: "Cargos");

            migrationBuilder.AddColumn<string>(
                name: "Tipo",
                table: "Usuario",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}
