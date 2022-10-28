using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMinsait.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cobradores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Salario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobradores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cnh = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Salario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "passagem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DestinoSaida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DestinoChegada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorarioSaida = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HorarioChegada = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Preco = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_passagem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Onibus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotoristaId = table.Column<int>(type: "int", nullable: true),
                    CobradorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onibus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Onibus_Cobradores_CobradorId",
                        column: x => x.CobradorId,
                        principalTable: "Cobradores",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Onibus_Motoristas_MotoristaId",
                        column: x => x.MotoristaId,
                        principalTable: "Motoristas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    seguro = table.Column<bool>(type: "bit", nullable: true),
                    Assento = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    OnibusId = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passageiros_Onibus_OnibusId",
                        column: x => x.OnibusId,
                        principalTable: "Onibus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Onibus_CobradorId",
                table: "Onibus",
                column: "CobradorId");

            migrationBuilder.CreateIndex(
                name: "IX_Onibus_MotoristaId",
                table: "Onibus",
                column: "MotoristaId");

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_OnibusId",
                table: "Passageiros",
                column: "OnibusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passageiros");

            migrationBuilder.DropTable(
                name: "passagem");

            migrationBuilder.DropTable(
                name: "Onibus");

            migrationBuilder.DropTable(
                name: "Cobradores");

            migrationBuilder.DropTable(
                name: "Motoristas");
        }
    }
}
