using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMinsait.Migrations
{
    public partial class relacionamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Onibus_Motoristas_MotoristaId",
                table: "Onibus");

            migrationBuilder.DropIndex(
                name: "IX_Onibus_MotoristaId",
                table: "Onibus");

            migrationBuilder.DropColumn(
                name: "MotoristaId",
                table: "Onibus");

            migrationBuilder.AddColumn<int>(
                name: "OnibusId",
                table: "Motoristas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Motoristas_OnibusId",
                table: "Motoristas",
                column: "OnibusId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Motoristas_Onibus_OnibusId",
                table: "Motoristas",
                column: "OnibusId",
                principalTable: "Onibus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Motoristas_Onibus_OnibusId",
                table: "Motoristas");

            migrationBuilder.DropIndex(
                name: "IX_Motoristas_OnibusId",
                table: "Motoristas");

            migrationBuilder.DropColumn(
                name: "OnibusId",
                table: "Motoristas");

            migrationBuilder.AddColumn<int>(
                name: "MotoristaId",
                table: "Onibus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Onibus_MotoristaId",
                table: "Onibus",
                column: "MotoristaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Onibus_Motoristas_MotoristaId",
                table: "Onibus",
                column: "MotoristaId",
                principalTable: "Motoristas",
                principalColumn: "Id");
        }
    }
}
