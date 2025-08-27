using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS_MediatR_RentACar.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_ai_response : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarRecommendationAIs",
                columns: table => new
                {
                    CarRecommendationAIID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerPrompt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AIResponse1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AIResponse2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AIResponse3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarRecommendationAIs", x => x.CarRecommendationAIID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarRecommendationAIs");
        }
    }
}
