using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMinsait.Migrations
{
    public partial class updateFinal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passageiros_Passagem_PassagemId",
                table: "Passageiros");

            migrationBuilder.AddForeignKey(
                name: "FK_Passageiros_Passagem_PassagemId",
                table: "Passageiros",
                column: "PassagemId",
                principalTable: "Passagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passageiros_Passagem_PassagemId",
                table: "Passageiros");

            migrationBuilder.AddForeignKey(
                name: "FK_Passageiros_Passagem_PassagemId",
                table: "Passageiros",
                column: "PassagemId",
                principalTable: "Passagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
