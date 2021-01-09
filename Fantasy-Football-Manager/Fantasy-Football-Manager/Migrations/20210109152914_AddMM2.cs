using Microsoft.EntityFrameworkCore.Migrations;

namespace Fantasy_Football_Manager.Migrations
{
    public partial class AddMM2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Echipe_Jucatori_JucatorId",
                table: "Echipe");

            migrationBuilder.DropIndex(
                name: "IX_Echipe_JucatorId",
                table: "Echipe");

            migrationBuilder.DropColumn(
                name: "JucatorId",
                table: "Echipe");

            migrationBuilder.CreateTable(
                name: "EchipeJucatori",
                columns: table => new
                {
                    EchipaId = table.Column<int>(nullable: false),
                    JucatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EchipeJucatori", x => new { x.EchipaId, x.JucatorId });
                    table.ForeignKey(
                        name: "FK_EchipeJucatori_Echipe_EchipaId",
                        column: x => x.EchipaId,
                        principalTable: "Echipe",
                        principalColumn: "EchipaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EchipeJucatori_Jucatori_JucatorId",
                        column: x => x.JucatorId,
                        principalTable: "Jucatori",
                        principalColumn: "JucatorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EchipeJucatori_JucatorId",
                table: "EchipeJucatori",
                column: "JucatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EchipeJucatori");

            migrationBuilder.AddColumn<int>(
                name: "JucatorId",
                table: "Echipe",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Echipe_JucatorId",
                table: "Echipe",
                column: "JucatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Echipe_Jucatori_JucatorId",
                table: "Echipe",
                column: "JucatorId",
                principalTable: "Jucatori",
                principalColumn: "JucatorId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
