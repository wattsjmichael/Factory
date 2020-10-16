using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Factory.Migrations
{
    public partial class Expertise : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expertises",
                columns: table => new
                {
                    ExpertiseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExpertiseArea = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expertises", x => x.ExpertiseId);
                });

            migrationBuilder.CreateTable(
                name: "EngineerExpertise",
                columns: table => new
                {
                    EngineerExpertiseId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ExpertiseId = table.Column<int>(nullable: false),
                    EngineerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EngineerExpertise", x => x.EngineerExpertiseId);
                    table.ForeignKey(
                        name: "FK_EngineerExpertise_Engineers_EngineerId",
                        column: x => x.EngineerId,
                        principalTable: "Engineers",
                        principalColumn: "EngineerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EngineerExpertise_Expertises_ExpertiseId",
                        column: x => x.ExpertiseId,
                        principalTable: "Expertises",
                        principalColumn: "ExpertiseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EngineerExpertise_EngineerId",
                table: "EngineerExpertise",
                column: "EngineerId");

            migrationBuilder.CreateIndex(
                name: "IX_EngineerExpertise_ExpertiseId",
                table: "EngineerExpertise",
                column: "ExpertiseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EngineerExpertise");

            migrationBuilder.DropTable(
                name: "Expertises");
        }
    }
}
