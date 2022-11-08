using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMinsait.Migrations
{
    public partial class passageiroupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeCompleto",
                table: "Passageiros",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeCompleto",
                table: "Passageiros");
        }
    }
}
