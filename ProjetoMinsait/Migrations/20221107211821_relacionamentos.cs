using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMinsait.Migrations
{
    public partial class relacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PassageiroId",
                table: "Passagem",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "OnibusId",
                table: "Passageiros",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Salario",
                table: "Motoristas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MotoristaOnibusId",
                table: "Motoristas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "Salario",
                table: "Cobradores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<decimal>(
                name: "Salario",
                table: "Motoristas",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Salario",
                table: "Cobradores",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}
