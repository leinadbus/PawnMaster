using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnMaster.Persistence.Migrations
{
    public partial class CambioDatoFechaPartidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TiempoDeJuego",
                table: "Partidas");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreaciónPartida",
                table: "Partidas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "PosiciónVertical",
                table: "Fichas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "PosiciónHorizontal",
                table: "Fichas",
                type: "nvarchar(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FechaCreaciónPartida",
                table: "Partidas");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TiempoDeJuego",
                table: "Partidas",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AlterColumn<int>(
                name: "PosiciónVertical",
                table: "Fichas",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PosiciónHorizontal",
                table: "Fichas",
                type: "nvarchar(1)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldNullable: true);
        }
    }
}
