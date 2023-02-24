using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaEduEscola.Migrations
{
    public partial class CriacaoTabelaBanco1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMateria = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Professor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TurmaId = table.Column<int>(type: "int", nullable: false),
                    UnidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Materias_Unidades_UnidadeId",
                        column: x => x.UnidadeId,
                        principalTable: "Unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Professors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeProfessor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Turmas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoTurma = table.Column<int>(type: "int", nullable: false),
                    QtdAlunos = table.Column<int>(type: "int", nullable: false),
                    UnidadeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Turmas_Alunos_QtdAlunos",
                        column: x => x.QtdAlunos,
                        principalTable: "Alunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Materias_UnidadeId",
                table: "Materias",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_QtdAlunos",
                table: "Turmas",
                column: "QtdAlunos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Materias");

            migrationBuilder.DropTable(
                name: "Professors");

            migrationBuilder.DropTable(
                name: "Turmas");
        }
    }
}
