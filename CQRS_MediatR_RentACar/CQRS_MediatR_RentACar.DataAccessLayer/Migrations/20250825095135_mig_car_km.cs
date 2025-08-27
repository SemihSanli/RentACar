using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CQRS_MediatR_RentACar.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig_car_km : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CarKM",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CarKM",
                table: "Cars");
        }
    }
}
