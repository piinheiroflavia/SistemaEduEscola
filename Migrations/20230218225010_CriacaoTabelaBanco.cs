    using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaEduEscola.Migrations
{
    public partial class CriacaoTabelaBanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<int>(type: "int", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Matricula = table.Column<int>(type: "int", nullable: false),
                    TurmaId = table.Column<int>(type: "int", nullable: false),
                    UnidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Unidades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeUnidade = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Enderoco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdAlunos = table.Column<int>(type: "int", nullable: false),
                    QtdTurmas = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidades", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Unidades");
        }
    }
}
