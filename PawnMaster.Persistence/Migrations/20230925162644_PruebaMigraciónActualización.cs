using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnMaster.Persistence.Migrations
{
    public partial class PruebaMigraciónActualización : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TurnoPartida",
                table: "Partidas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TurnoPartida",
                table: "Partidas");
        }
    }
}
