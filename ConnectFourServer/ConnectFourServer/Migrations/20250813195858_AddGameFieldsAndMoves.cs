using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ConnectFourServer.Migrations
{
    /// <inheritdoc />
    public partial class AddGameFieldsAndMoves : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_PlayerId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "MovesJson",
                table: "Games",
                newName: "Result");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Games",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<int>(
                name: "PlayerMoves",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServerMoves",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Who = table.Column<int>(type: "int", nullable: false),
                    Column = table.Column<int>(type: "int", nullable: false),
                    Row = table.Column<int>(type: "int", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moves_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Moves_GameId",
                table: "Moves",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_PlayerId",
                table: "Games",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Players_PlayerId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "PlayerMoves",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ServerMoves",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "Games",
                newName: "MovesJson");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Players_PlayerId",
                table: "Games",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }
    }
}
