using Microsoft.EntityFrameworkCore.Migrations;

namespace MagSeguros.Migrations
{
    public partial class CriandoVinculoNaTbSegurado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cep",
                table: "Segurado",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "Segurado",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ComplementoEnd",
                table: "Segurado",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CpfBeneficiario",
                table: "Segurado",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DoencaGrave",
                table: "Segurado",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmaiBeneficiario",
                table: "Segurado",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Segurado",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Segurado",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeBeneficiario",
                table: "Segurado",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Parcela",
                table: "Segurado",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Premio",
                table: "Segurado",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uf",
                table: "Segurado",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Funcionario",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionario",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Funcionario",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Funcionario",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Segurado_FuncionarioId",
                table: "Segurado",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Segurado_Funcionario_FuncionarioId",
                table: "Segurado",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Segurado_Funcionario_FuncionarioId",
                table: "Segurado");

            migrationBuilder.DropIndex(
                name: "IX_Segurado_FuncionarioId",
                table: "Segurado");

            migrationBuilder.DropColumn(
                name: "Cep",
                table: "Segurado");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Segurado");

            migrationBuilder.DropColumn(
                name: "ComplementoEnd",
                table: "Segurado");

            migrationBuilder.DropColumn(
                name: "CpfBeneficiario",
                table: "Segurado");

            migrationBuilder.DropColumn(
                name: "DoencaGrave",
                table: "Segurado");

            migrationBuilder.DropColumn(
                name: "EmaiBeneficiario",
                table: "Segurado");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Segurado");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Segurado");

            migrationBuilder.DropColumn(
                name: "NomeBeneficiario",
                table: "Segurado");

            migrationBuilder.DropColumn(
                name: "Parcela",
                table: "Segurado");

            migrationBuilder.DropColumn(
                name: "Premio",
                table: "Segurado");

            migrationBuilder.DropColumn(
                name: "Uf",
                table: "Segurado");

            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Funcionario",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionario",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Funcionario",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Funcionario",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
