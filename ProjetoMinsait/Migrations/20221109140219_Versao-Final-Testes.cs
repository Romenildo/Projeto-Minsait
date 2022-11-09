using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMinsait.Migrations
{
    public partial class VersaoFinalTestes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Onibus",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeViacao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Onibus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cobradores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Salario = table.Column<double>(type: "float", nullable: false),
                    OnibusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobradores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cobradores_Onibus_OnibusId",
                        column: x => x.OnibusId,
                        principalTable: "Onibus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Motoristas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Cnh = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Salario = table.Column<double>(type: "float", nullable: false),
                    OnibusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motoristas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motoristas_Onibus_OnibusId",
                        column: x => x.OnibusId,
                        principalTable: "Onibus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Passagem",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinoSaida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DestinoChegada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorarioSaida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HorarioChegada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoPassagem = table.Column<double>(type: "float", nullable: false),
                    OnibusId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passagem_Onibus_OnibusId",
                        column: x => x.OnibusId,
                        principalTable: "Onibus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Passageiros",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Seguro = table.Column<bool>(type: "bit", nullable: false),
                    Assento = table.Column<int>(type: "int", nullable: true),
                    Tipo = table.Column<int>(type: "int", nullable: false),
                    PassagemId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ValorPassagem = table.Column<double>(type: "float", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Rg = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DataNascimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Contato = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passageiros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passageiros_Passagem_PassagemId",
                        column: x => x.PassagemId,
                        principalTable: "Passagem",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cobradores_OnibusId",
                table: "Cobradores",
                column: "OnibusId",
                unique: true,
                filter: "[OnibusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_OnibusId",
                table: "Motoristas",
                column: "OnibusId",
                unique: true,
                filter: "[OnibusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_PassagemId",
                table: "Passageiros",
                column: "PassagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_OnibusId",
                table: "Passagem",
                column: "OnibusId",
                unique: true,
                filter: "[OnibusId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cobradores");

            migrationBuilder.DropTable(
                name: "Motoristas");

            migrationBuilder.DropTable(
                name: "Passageiros");

            migrationBuilder.DropTable(
                name: "Passagem");

            migrationBuilder.DropTable(
                name: "Onibus");
        }
    }
}
