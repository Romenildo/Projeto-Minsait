using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMinsait.Migrations
{
    public partial class FinalUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passageiros_Passagem_PassagemId",
                table: "Passageiros");

            migrationBuilder.DropForeignKey(
                name: "FK_Passagem_Onibus_OnibusId",
                table: "Passagem");

            migrationBuilder.AddForeignKey(
                name: "FK_Passageiros_Passagem_PassagemId",
                table: "Passageiros",
                column: "PassagemId",
                principalTable: "Passagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Passagem_Onibus_OnibusId",
                table: "Passagem",
                column: "OnibusId",
                principalTable: "Onibus",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passageiros_Passagem_PassagemId",
                table: "Passageiros");

            migrationBuilder.DropForeignKey(
                name: "FK_Passagem_Onibus_OnibusId",
                table: "Passagem");

            migrationBuilder.AddForeignKey(
                name: "FK_Passageiros_Passagem_PassagemId",
                table: "Passageiros",
                column: "PassagemId",
                principalTable: "Passagem",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Passagem_Onibus_OnibusId",
                table: "Passagem",
                column: "OnibusId",
                principalTable: "Onibus",
                principalColumn: "Id");
        }
    }
}
