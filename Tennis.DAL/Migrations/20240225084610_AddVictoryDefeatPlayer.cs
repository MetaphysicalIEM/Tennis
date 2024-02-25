using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tennis.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddVictoryDefeatPlayer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DefeatNumber",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VictoryNumber",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DefeatNumber",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "VictoryNumber",
                table: "Players");
        }
    }
}
