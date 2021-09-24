using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjCursoAPIDotNetCoreMVC.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enfermeiro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPF = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodigoInternoEnfermeiro = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermeiro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaterialConsumo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QtdProduto = table.Column<int>(type: "int", nullable: false),
                    EnfermeiroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialConsumo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialConsumo_Enfermeiro_EnfermeiroId",
                        column: x => x.EnfermeiroId,
                        principalTable: "Enfermeiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Medicamento",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dosagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnidadeDosagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnfermeiroId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicamento_Enfermeiro_EnfermeiroId",
                        column: x => x.EnfermeiroId,
                        principalTable: "Enfermeiro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MaterialConsumo_EnfermeiroId",
                table: "MaterialConsumo",
                column: "EnfermeiroId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamento_EnfermeiroId",
                table: "Medicamento",
                column: "EnfermeiroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "MaterialConsumo");

            migrationBuilder.DropTable(
                name: "Medicamento");

            migrationBuilder.DropTable(
                name: "Enfermeiro");
        }
    }
}
