using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnMaster.Persistence.Migrations
{
    public partial class refactorCaracterFichaAFichas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Caracterficha",
                table: "Fichas",
                newName: "CaracterFicha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CaracterFicha",
                table: "Fichas",
                newName: "Caracterficha");
        }
    }
}
