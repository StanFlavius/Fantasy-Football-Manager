using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Fantasy_Football_Manager.Migrations
{
    public partial class InitDB2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LigaId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Ligi",
                columns: table => new
                {
                    LigaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeLiga = table.Column<string>(nullable: false),
                    NrMaxUseri = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ligi", x => x.LigaId);
                });

            migrationBuilder.CreateTable(
                name: "StatisticiJucatori",
                columns: table => new
                {
                    StatisticiJucatorId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NrGoluri = table.Column<int>(nullable: false),
                    NrAssists = table.Column<int>(nullable: false),
                    NrCleansheets = table.Column<int>(nullable: false),
                    NrTotalPuncte = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatisticiJucatori", x => x.StatisticiJucatorId);
                });

            migrationBuilder.CreateTable(
                name: "Echipe",
                columns: table => new
                {
                    EchipaId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(nullable: true),
                    NumeEchipa = table.Column<string>(nullable: false),
                    NrTotalPuncte = table.Column<int>(nullable: false),
                    LigaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Echipe", x => x.EchipaId);
                    table.ForeignKey(
                        name: "FK_Echipe_Ligi_LigaId",
                        column: x => x.LigaId,
                        principalTable: "Ligi",
                        principalColumn: "LigaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Echipe_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jucatori",
                columns: table => new
                {
                    JucatorId = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeJucator = table.Column<string>(nullable: false),
                    PrenumeJucator = table.Column<string>(nullable: false),
                    PozitieJucator = table.Column<string>(nullable: false),
                    EchipaFotbal = table.Column<string>(nullable: false),
                    StatisticiJucatorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jucatori", x => x.JucatorId);
                    table.ForeignKey(
                        name: "FK_Jucatori_StatisticiJucatori_StatisticiJucatorId",
                        column: x => x.StatisticiJucatorId,
                        principalTable: "StatisticiJucatori",
                        principalColumn: "StatisticiJucatorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_LigaId",
                table: "AspNetUsers",
                column: "LigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Echipe_LigaId",
                table: "Echipe",
                column: "LigaId");

            migrationBuilder.CreateIndex(
                name: "IX_Echipe_UserId",
                table: "Echipe",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jucatori_StatisticiJucatorId",
                table: "Jucatori",
                column: "StatisticiJucatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Ligi_LigaId",
                table: "AspNetUsers",
                column: "LigaId",
                principalTable: "Ligi",
                principalColumn: "LigaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Ligi_LigaId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Echipe");

            migrationBuilder.DropTable(
                name: "Jucatori");

            migrationBuilder.DropTable(
                name: "Ligi");

            migrationBuilder.DropTable(
                name: "StatisticiJucatori");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_LigaId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LigaId",
                table: "AspNetUsers");
        }
    }
}
