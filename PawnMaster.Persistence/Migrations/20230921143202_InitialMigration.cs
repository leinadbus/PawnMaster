using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawnMaster.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jugadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RutaImagen = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CreacionCuenta = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jugadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TiempoDeJuego = table.Column<TimeSpan>(type: "time", nullable: false),
                    PartidaEnJuego = table.Column<bool>(type: "bit", nullable: false),
                    Ganador = table.Column<int>(type: "int", nullable: false),
                    JugadorBlancoId = table.Column<int>(type: "int", nullable: false),
                    JugadorNegroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Partidas_Jugadores_JugadorBlancoId",
                        column: x => x.JugadorBlancoId,
                        principalTable: "Jugadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidas_Jugadores_JugadorNegroId",
                        column: x => x.JugadorNegroId,
                        principalTable: "Jugadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fichas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    partidaId = table.Column<int>(type: "int", nullable: false),
                    NumeroMovimientos = table.Column<int>(type: "int", nullable: false),
                    PosiciónHorizontal = table.Column<string>(type: "nvarchar(1)", nullable: false),
                    PosiciónVertical = table.Column<int>(type: "int", nullable: false),
                    EnJuego = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fichas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fichas_Partidas_partidaId",
                        column: x => x.partidaId,
                        principalTable: "Partidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fichas_partidaId",
                table: "Fichas",
                column: "partidaId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_JugadorBlancoId",
                table: "Partidas",
                column: "JugadorBlancoId");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_JugadorNegroId",
                table: "Partidas",
                column: "JugadorNegroId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fichas");

            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropTable(
                name: "Jugadores");
        }
    }
}
