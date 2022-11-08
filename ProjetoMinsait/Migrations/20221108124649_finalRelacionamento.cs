using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMinsait.Migrations
{
    public partial class finalRelacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motoristas_Onibus_MotoristaOnibusId",
                table: "Motoristas");

            migrationBuilder.DropForeignKey(
                name: "FK_Passageiros_Onibus_OnibusId",
                table: "Passageiros");

            migrationBuilder.DropForeignKey(
                name: "FK_Passagem_Passageiros_PassageiroId",
                table: "Passagem");

            migrationBuilder.DropIndex(
                name: "IX_Passagem_PassageiroId",
                table: "Passagem");

            migrationBuilder.DropIndex(
                name: "IX_Passageiros_OnibusId",
                table: "Passageiros");

            migrationBuilder.DropIndex(
                name: "IX_Motoristas_MotoristaOnibusId",
                table: "Motoristas");

            migrationBuilder.DropColumn(
                name: "PassageiroId",
                table: "Passagem");

            migrationBuilder.DropColumn(
                name: "OnibusId",
                table: "Passageiros");

            migrationBuilder.DropColumn(
                name: "MotoristaOnibusId",
                table: "Motoristas");

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Passageiros",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Passageiros",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Passageiros",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PassagemId",
                table: "Onibus",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Motoristas",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Motoristas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Cnh",
                table: "Motoristas",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<Guid>(
                name: "OnibusId",
                table: "Motoristas",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Motoristas",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Cobradores",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cobradores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddColumn<Guid>(
                name: "OnibusId",
                table: "Cobradores",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sobrenome",
                table: "Cobradores",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Onibus_PassagemId",
                table: "Onibus",
                column: "PassagemId",
                unique: true,
                filter: "[PassagemId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_OnibusId",
                table: "Motoristas",
                column: "OnibusId",
                unique: true,
                filter: "[OnibusId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cobradores_OnibusId",
                table: "Cobradores",
                column: "OnibusId",
                unique: true,
                filter: "[OnibusId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cobradores_Onibus_OnibusId",
                table: "Cobradores",
                column: "OnibusId",
                principalTable: "Onibus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Motoristas_Onibus_OnibusId",
                table: "Motoristas",
                column: "OnibusId",
                principalTable: "Onibus",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Onibus_Passagem_PassagemId",
                table: "Onibus",
                column: "PassagemId",
                principalTable: "Passagem",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cobradores_Onibus_OnibusId",
                table: "Cobradores");

            migrationBuilder.DropForeignKey(
                name: "FK_Motoristas_Onibus_OnibusId",
                table: "Motoristas");

            migrationBuilder.DropForeignKey(
                name: "FK_Onibus_Passagem_PassagemId",
                table: "Onibus");

            migrationBuilder.DropIndex(
                name: "IX_Onibus_PassagemId",
                table: "Onibus");

            migrationBuilder.DropIndex(
                name: "IX_Motoristas_OnibusId",
                table: "Motoristas");

            migrationBuilder.DropIndex(
                name: "IX_Cobradores_OnibusId",
                table: "Cobradores");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Passageiros");

            migrationBuilder.DropColumn(
                name: "PassagemId",
                table: "Onibus");

            migrationBuilder.DropColumn(
                name: "OnibusId",
                table: "Motoristas");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Motoristas");

            migrationBuilder.DropColumn(
                name: "OnibusId",
                table: "Cobradores");

            migrationBuilder.DropColumn(
                name: "Sobrenome",
                table: "Cobradores");

            migrationBuilder.AddColumn<Guid>(
                name: "PassageiroId",
                table: "Passagem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Passageiros",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Passageiros",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<Guid>(
                name: "OnibusId",
                table: "Passageiros",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Motoristas",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Motoristas",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Cnh",
                table: "Motoristas",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AddColumn<Guid>(
                name: "MotoristaOnibusId",
                table: "Motoristas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Cobradores",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cobradores",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_PassageiroId",
                table: "Passagem",
                column: "PassageiroId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passageiros_OnibusId",
                table: "Passageiros",
                column: "OnibusId");

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_MotoristaOnibusId",
                table: "Motoristas",
                column: "MotoristaOnibusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Motoristas_Onibus_MotoristaOnibusId",
                table: "Motoristas",
                column: "MotoristaOnibusId",
                principalTable: "Onibus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passageiros_Onibus_OnibusId",
                table: "Passageiros",
                column: "OnibusId",
                principalTable: "Onibus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Passagem_Passageiros_PassageiroId",
                table: "Passagem",
                column: "PassageiroId",
                principalTable: "Passageiros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
