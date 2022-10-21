using Microsoft.EntityFrameworkCore.Migrations;

namespace MagSeguros.Migrations
{
    public partial class CorrigindoFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Segurado_Funcionario_FuncionarioId",
                table: "Segurado");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Segurado",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Segurado_Funcionario_FuncionarioId",
                table: "Segurado",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Segurado_Funcionario_FuncionarioId",
                table: "Segurado");

            migrationBuilder.AlterColumn<int>(
                name: "FuncionarioId",
                table: "Segurado",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Segurado_Funcionario_FuncionarioId",
                table: "Segurado",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
