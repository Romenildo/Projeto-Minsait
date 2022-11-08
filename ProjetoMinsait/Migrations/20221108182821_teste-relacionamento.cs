using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMinsait.Migrations
{
    public partial class testerelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Onibus_PassagemId",
                table: "Onibus");

            migrationBuilder.AddColumn<Guid>(
                name: "PassagemId",
                table: "Passageiros",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_PassagemId",
                table: "Passageiros",
                column: "PassagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Onibus_PassagemId",
                table: "Onibus",
                column: "PassagemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Passageiros_Passagem_PassagemId",
                table: "Passageiros",
                column: "PassagemId",
                principalTable: "Passagem",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passageiros_Passagem_PassagemId",
                table: "Passageiros");

            migrationBuilder.DropIndex(
                name: "IX_Passageiros_PassagemId",
                table: "Passageiros");

            migrationBuilder.DropIndex(
                name: "IX_Onibus_PassagemId",
                table: "Onibus");

            migrationBuilder.DropColumn(
                name: "PassagemId",
                table: "Passageiros");

            migrationBuilder.CreateIndex(
                name: "IX_Onibus_PassagemId",
                table: "Onibus",
                column: "PassagemId",
                unique: true,
                filter: "[PassagemId] IS NOT NULL");
        }
    }
}
