using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy_Football_Manager.Migrations
{
    public partial class AddMM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Ligi_LigaId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LigaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LigaId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "JucatorId",
                table: "Echipe",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "UsersLigi",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LigaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersLigi", x => new { x.UserId, x.LigaId });
                    table.ForeignKey(
                        name: "FK_UsersLigi_Ligi_LigaId",
                        column: x => x.LigaId,
                        principalTable: "Ligi",
                        principalColumn: "LigaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersLigi_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Echipe_JucatorId",
                table: "Echipe",
                column: "JucatorId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersLigi_LigaId",
                table: "UsersLigi",
                column: "LigaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Echipe_Jucatori_JucatorId",
                table: "Echipe",
                column: "JucatorId",
                principalTable: "Jucatori",
                principalColumn: "JucatorId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Echipe_Jucatori_JucatorId",
                table: "Echipe");

            migrationBuilder.DropTable(
                name: "UsersLigi");

            migrationBuilder.DropIndex(
                name: "IX_Echipe_JucatorId",
                table: "Echipe");

            migrationBuilder.DropColumn(
                name: "JucatorId",
                table: "Echipe");

            migrationBuilder.AddColumn<int>(
                name: "LigaId",
                table: "AspNetUsers",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LigaId",
                table: "AspNetUsers",
                column: "LigaId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Ligi_LigaId",
                table: "AspNetUsers",
                column: "LigaId",
                principalTable: "Ligi",
                principalColumn: "LigaId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
