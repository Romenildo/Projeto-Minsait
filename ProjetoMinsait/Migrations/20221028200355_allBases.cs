using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoMinsait.Migrations
{
    public partial class allBases : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_passagem",
                table: "passagem");

            migrationBuilder.RenameTable(
                name: "passagem",
                newName: "Passagem");

            migrationBuilder.RenameColumn(
                name: "seguro",
                table: "Passageiros",
                newName: "Seguro");

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Passageiros",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Passageiros",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Cobradores",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cobradores",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Passagem",
                table: "Passagem",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Passagem",
                table: "Passagem");

            migrationBuilder.RenameTable(
                name: "Passagem",
                newName: "passagem");

            migrationBuilder.RenameColumn(
                name: "Seguro",
                table: "Passageiros",
                newName: "seguro");

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Passageiros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Passageiros",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AlterColumn<string>(
                name: "Rg",
                table: "Cobradores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cobradores",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.AddPrimaryKey(
                name: "PK_passagem",
                table: "passagem",
                column: "Id");
        }
    }
}
