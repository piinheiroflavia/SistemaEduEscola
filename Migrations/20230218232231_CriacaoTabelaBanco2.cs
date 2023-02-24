using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaEduEscola.Migrations
{
    public partial class CriacaoTabelaBanco2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Turmas_QtdAlunos",
                table: "Turmas");

            migrationBuilder.AlterColumn<string>(
                name: "UnidadeId",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Alunos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "UnidadesId",
                table: "Alunos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_QtdAlunos",
                table: "Turmas",
                column: "QtdAlunos",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Alunos_UnidadesId",
                table: "Alunos",
                column: "UnidadesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alunos_Unidades_UnidadesId",
                table: "Alunos",
                column: "UnidadesId",
                principalTable: "Unidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alunos_Unidades_UnidadesId",
                table: "Alunos");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_QtdAlunos",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Alunos_UnidadesId",
                table: "Alunos");

            migrationBuilder.DropColumn(
                name: "UnidadesId",
                table: "Alunos");

            migrationBuilder.AlterColumn<int>(
                name: "UnidadeId",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Cpf",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_QtdAlunos",
                table: "Turmas",
                column: "QtdAlunos");
        }
    }
}
