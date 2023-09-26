using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnMaster.Persistence.Migrations
{
    public partial class RefactorizaciónDatoColorFicha : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Fichas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Fichas");
        }
    }
}
