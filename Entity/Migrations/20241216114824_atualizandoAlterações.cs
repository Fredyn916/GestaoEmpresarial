using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entity.Migrations
{
    public partial class atualizandoAlterações : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Usuario_UsuarioId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_TiposUsuario_TipoUsuarioId",
                table: "Usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario");

            migrationBuilder.RenameTable(
                name: "Usuario",
                newName: "Usuarios");

            migrationBuilder.RenameIndex(
                name: "IX_Usuario_TipoUsuarioId",
                table: "Usuarios",
                newName: "IX_Usuarios_TipoUsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Usuarios_UsuarioId",
                table: "Empresas",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_TiposUsuario_TipoUsuarioId",
                table: "Usuarios",
                column: "TipoUsuarioId",
                principalTable: "TiposUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Empresas_Usuarios_UsuarioId",
                table: "Empresas");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_TiposUsuario_TipoUsuarioId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Usuario");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_TipoUsuarioId",
                table: "Usuario",
                newName: "IX_Usuario_TipoUsuarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuario",
                table: "Usuario",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Empresas_Usuario_UsuarioId",
                table: "Empresas",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuario_TiposUsuario_TipoUsuarioId",
                table: "Usuario",
                column: "TipoUsuarioId",
                principalTable: "TiposUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
